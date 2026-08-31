using Soenneker.Sonarr.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Sonarr.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily initialized Sonarr API client.
/// </summary>
public interface ISonarrOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared client for this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SonarrOpenApiClient> Get(CancellationToken cancellationToken = default);

    /// <summary>Releases resources used by this utility.</summary>
    new void Dispose();

    /// <summary>Asynchronously releases resources used by this utility.</summary>
    new ValueTask DisposeAsync();
}
