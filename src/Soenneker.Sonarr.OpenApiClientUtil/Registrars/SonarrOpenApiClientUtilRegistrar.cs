using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Sonarr.HttpClients.Registrars;
using Soenneker.Sonarr.OpenApiClientUtil.Abstract;

namespace Soenneker.Sonarr.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class SonarrOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="SonarrOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSonarrOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSonarrOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISonarrOpenApiClientUtil, SonarrOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="SonarrOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSonarrOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSonarrOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISonarrOpenApiClientUtil, SonarrOpenApiClientUtil>();

        return services;
    }
}
