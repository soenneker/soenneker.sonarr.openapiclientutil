using Soenneker.Sonarr.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Sonarr.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class SonarrOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ISonarrOpenApiClientUtil _openapiclientutil;

    public SonarrOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ISonarrOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
