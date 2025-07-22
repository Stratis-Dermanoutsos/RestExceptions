using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions;

public class RestExceptionHandler(
    IProblemDetailsService problemDetailsService,
    IRestExceptionProblemDetailsBuilder? problemDetailsBuilder = null)
    : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService = problemDetailsService;
    private readonly IRestExceptionProblemDetailsBuilder _problemDetailsBuilder =
        problemDetailsBuilder ?? new DefaultRestExceptionProblemDetailsBuilder();
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken = default)
    {
        var restException = exception.MapToRestException();

        var problemDetails = _problemDetailsBuilder.Build(httpContext, restException);

        httpContext.Response.StatusCode = (int)restException.StatusCode;
        return await _problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });
    }
}
