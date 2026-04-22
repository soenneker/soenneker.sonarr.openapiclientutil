using Soenneker.Sonarr.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Sonarr.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SonarrOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ISonarrOpenApiClientUtil _openapiclientutil;

    public SonarrOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ISonarrOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
