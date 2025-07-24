using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions;

/// <summary>
/// Custom example implementation of <see cref="IRestExceptionProblemDetailsBuilder"/>.
/// It exists to demonstrate how to create a custom builder for <see cref="ProblemDetails"/> from a <see cref="RestException"/>.
/// <br/>
/// This example simply modifies the <see cref="ProblemDetails"/> by setting the <see cref="RestException.Title"/> to the <see cref="ProblemDetails.Detail"/>
/// and the <see cref="RestException.Message"/> to the <see cref="ProblemDetails.Title"/>.
/// </summary>
public class CustomExampleRestExceptionProblemDetailsBuilder : IRestExceptionProblemDetailsBuilder
{
    public ProblemDetails Build(HttpContext httpContext, RestException restException)
    {
        var defaultBuilder = new DefaultRestExceptionProblemDetailsBuilder();
        var problemDetails = defaultBuilder.Build(httpContext, restException);
        problemDetails.Detail = restException.Title;
        problemDetails.Title = restException.Message;

        return problemDetails;
    }
}
