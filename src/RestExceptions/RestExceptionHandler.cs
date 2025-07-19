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
        if (exception is not RestException restException)
        {
            var internalServerError = new InternalServerErrorRestException();
            var internalServerErrorProblemDetails = new ProblemDetails
            {
                Status = (int)internalServerError.StatusCode,
                Title = internalServerError.Title,
                Detail = internalServerError.Message,
                Type = internalServerError.GetType().Name
            };

            httpContext.Response.StatusCode = (int)internalServerError.StatusCode;
            return await problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext
                {
                    HttpContext = httpContext,
                    ProblemDetails = internalServerErrorProblemDetails
                });
        }

        var problemDetails = new ProblemDetails
        {
            Status = (int)restException.StatusCode,
            Title = restException.Title,
            Detail = restException.Message,
            Type = restException.GetType().Name // TODO
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
