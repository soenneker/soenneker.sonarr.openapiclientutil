using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Sonarr.HttpClients.Abstract;
using Soenneker.Sonarr.OpenApiClientUtil.Abstract;
using Soenneker.Sonarr.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Sonarr.OpenApiClientUtil;

///<inheritdoc cref="ISonarrOpenApiClientUtil"/>
public sealed class SonarrOpenApiClientUtil : ISonarrOpenApiClientUtil
{
    private readonly AsyncSingleton<SonarrOpenApiClient> _client;

    public SonarrOpenApiClientUtil(ISonarrOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<SonarrOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Sonarr:ApiKey");
            string authHeaderValueTemplate = configuration["Sonarr:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new SonarrOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<SonarrOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
