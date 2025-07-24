using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions;

/// <summary>
/// Interface for building <see cref="ProblemDetails"/> from a <see cref="RestException"/>.
///
/// To customize the way <see cref="ProblemDetails"/> are created from a <see cref="RestException"/> to match your application's needs,
/// simply implement this interface and register your implementation in the DI container.
/// </summary>
/// <code>
/// // Example of a custom implementation
/// public class CustomRestExceptionProblemDetailsBuilder : IRestExceptionProblemDetailsBuilder
/// {
///     public ProblemDetails Build(HttpContext httpContext, RestException restException) { ... }
/// }
/// </code>
/// <code>
/// // In your Startup or Program class
/// builder.Services.AddSingleton&lt;IRestExceptionProblemDetailsBuilder, CustomRestExceptionProblemDetailsBuilder&gt;();
/// </code>
public interface IRestExceptionProblemDetailsBuilder
{
    /// <summary>
    /// Builds a <see cref="ProblemDetails"/> instance from the given <see cref="RestException"/>.
    /// Also includes the HTTP context to provide additional information, if needed.
    /// </summary>
    /// <param name="httpContext">The current HTTP context.</param>
    /// <param name="restException"></param>
    /// <returns></returns>
    ProblemDetails Build(HttpContext httpContext, RestException restException);
}
