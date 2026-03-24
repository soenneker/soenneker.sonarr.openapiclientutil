using Soenneker.Sonarr.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Sonarr.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ISonarrOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<SonarrOpenApiClient> Get(CancellationToken cancellationToken = default);
}
