using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions.Plugins;

/// <summary>
/// Example implementation of <see cref="IRestExceptionProblemDetailsBuilder"/> that
/// demonstrates how to customize the generated <see cref="ProblemDetails"/>.
/// </summary>
public sealed class CustomProblemDetailsBuilder : IRestExceptionProblemDetailsBuilder
{
    public ProblemDetails Build(HttpContext httpContext, RestException restException)
    {
        var problemDetails = new ProblemDetails
        {
            Status = (int)restException.StatusCode,
            Title = restException.Title,
            Detail = restException.Message,
            Type = $"https://www.rfc-editor.org/rfc/rfc9110.html#name-{restException.TypeSuffix}",
            Instance = httpContext.Request.Path
        };

        foreach (var kvp in restException.Extensions)
        {
            if (kvp.Value is null)
            {
                continue;
            }

            problemDetails.Extensions[kvp.Key] = kvp.Value;
        }

        problemDetails.Extensions["handledBy"] = "plugin";
        return problemDetails;
    }
}
