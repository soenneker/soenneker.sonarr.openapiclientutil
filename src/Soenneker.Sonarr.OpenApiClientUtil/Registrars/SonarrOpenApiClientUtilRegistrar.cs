using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Sonarr.HttpClients.Registrars;
using Soenneker.Sonarr.OpenApiClientUtil.Abstract;

namespace Soenneker.Sonarr.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Sonarr API client.
/// </summary>
public static class SonarrOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Sonarr API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSonarrOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSonarrOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISonarrOpenApiClientUtil, SonarrOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Sonarr API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddSonarrOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSonarrOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISonarrOpenApiClientUtil, SonarrOpenApiClientUtil>();

        return services;
    }
}
