[![](https://img.shields.io/nuget/v/soenneker.sonarr.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sonarr.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sonarr.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sonarr.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sonarr.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sonarr.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sonarr.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.sonarr.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Sonarr.OpenApiClientUtil

Provides a lazily initialized Sonarr client for series, episodes, files, calendars, queues, commands, indexers, download clients, quality profiles, notifications, and server configuration.

## Installation

```bash
dotnet add package Soenneker.Sonarr.OpenApiClientUtil
```

## Configuration

```json
{
  "Sonarr": {
    "ApiKey": "your-sonarr-api-key",
    "ClientBaseUrl": "http://localhost:8989"
  }
}
```

## Usage

```csharp
using Soenneker.Sonarr.OpenApiClientUtil.Abstract;
using Soenneker.Sonarr.OpenApiClientUtil.Registrars;

services.AddSonarrOpenApiClientUtilAsSingleton();

var client = await sonarrClientUtil.Get(cancellationToken);
var status = await client.Api.V3.System.Status.GetAsync(
    cancellationToken: cancellationToken);
```

Use `AddSonarrOpenApiClientUtilAsScoped()` for a separate generated wrapper per scope. Both registrations retain the singleton authenticated HTTP client provider, so disposing a scoped utility does not remove its client.
