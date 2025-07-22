global using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace RestExceptions;

public class RestExceptionHandler(
    IProblemDetailsService problemDetailsService,
    IRestExceptionProblemDetailsBuilder? problemDetailsBuilder = null)
    : IExceptionHandler
{
    private readonly IRestExceptionProblemDetailsBuilder _problemDetailsBuilder =
        problemDetailsBuilder ?? new DefaultRestExceptionProblemDetailsBuilder();
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken = default)
    {
        var restException = exception.MapToRestException();

        var problemDetails = _problemDetailsBuilder.Build(httpContext, restException);

        // Add the extensions from the RestException to the ProblemDetails
        foreach (var kvp in restException.Extensions)
        {
            if (kvp.Value is null)
            {
                continue;
            }

            problemDetails.Extensions[kvp.Key] = kvp.Value;
        }

        httpContext.Response.StatusCode = (int)restException.StatusCode;
        return await problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });
    }
}
