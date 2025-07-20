using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions;

public class RestExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken = default)
    {
        var restException = exception.MapToRestException();

        var problemDetails = new ProblemDetails
        {
            Status = (int)restException.StatusCode,
            Title = restException.Title,
            Detail = restException.Message,
            Type = $"https://www.rfc-editor.org/rfc/rfc9110.html#name-{restException.TypeSuffix}"
        };

        httpContext.Response.StatusCode = (int)restException.StatusCode;
        return await problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });
    }
}
