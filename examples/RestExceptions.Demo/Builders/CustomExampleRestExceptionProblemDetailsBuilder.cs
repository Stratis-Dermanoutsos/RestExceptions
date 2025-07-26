using Microsoft.AspNetCore.Mvc;

namespace RestExceptions.Demo.Builders;

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
        // Use the default builder to create a base ProblemDetails object
        var defaultBuilder = new DefaultRestExceptionProblemDetailsBuilder();
        var problemDetails = defaultBuilder.Build(httpContext, restException);

        // Modify the ProblemDetails as per the custom logic
        problemDetails.Detail = restException.Title;
        problemDetails.Title = "Message in title: " + restException.Message;

        return problemDetails;
    }
}
