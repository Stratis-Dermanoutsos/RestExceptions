using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions;

internal sealed class DefaultRestExceptionProblemDetailsBuilder : IRestExceptionProblemDetailsBuilder
{
    public ProblemDetails Build(HttpContext httpContext, RestException restException)
    {
        var problemDetails = new ProblemDetails
        {
            Status = (int)restException.StatusCode,
            Title = restException.Title,
            Detail = restException.Message,
            Type = $"https://www.rfc-editor.org/rfc/rfc9110.html#name-{restException.TypeSuffix}"
        };

        return problemDetails;
    }
}
