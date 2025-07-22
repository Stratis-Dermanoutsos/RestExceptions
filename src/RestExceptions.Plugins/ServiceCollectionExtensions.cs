using Microsoft.Extensions.DependencyInjection;

namespace RestExceptions.Plugins;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="CustomProblemDetailsBuilder"/> as the implementation of
    /// <see cref="IRestExceptionProblemDetailsBuilder"/>.
    /// </summary>
    public static IServiceCollection AddCustomRestExceptions(this IServiceCollection services)
    {
        services.AddSingleton<IRestExceptionProblemDetailsBuilder, CustomProblemDetailsBuilder>();
        return services;
    }
}
