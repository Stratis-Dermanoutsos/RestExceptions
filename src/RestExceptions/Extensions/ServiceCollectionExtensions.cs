using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;

namespace RestExceptions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the RestExceptions services in the DI container.
    /// This includes the ProblemDetails service and the ExceptionHandler middleware.
    /// </summary>
    /// <remarks>
    /// It is important to note that the ExceptionHandler middleware must be registered as well, otherwise the exceptions will not be handled correctly.
    /// For instance, in Minimal APIs, you can register it like so:
    /// <br/>
    /// <code>app.UseExceptionHandler();</code>
    /// </remarks>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns></returns>
    public static IServiceCollection AddRestExceptions(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance =
                    $"[{context.HttpContext.Request.Method}] {context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.Add("requestId", context.HttpContext.TraceIdentifier);

                var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
            };
        });
        services.AddExceptionHandler<RestExceptionHandler>();

        return services;
    }
}
