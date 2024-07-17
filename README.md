[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
![Nuget Package](https://badgen.net/nuget/v/AhbichtClient)

# AhbichtClient.NET
A client to use features of the Python library [AHBicht](https://github.com/Hochfrequenz/ahbicht) in the .NET universe.
For this library to work you need a backend, that exposes AHBicht features via a REST API.
This backend is available free of charge but without warranty by Hochfrequenz (based on Azure Functions).
Or you can host it yourself like any other microservice.
Hochfrequenz can provide you with a standalone Docker image; Contact [@JoschaMetze](https://github.com/joschametze) (`joscha.metze+ahbicht@hochfrequenz.de`).

## Installation

Install it from nuget [AhbichtClient](https://www.nuget.org/packages/AhbichtClient):

```bash
dotnet add package AhbichtClient
```

## How to use this library (Quickstart with public backend)

https://github.com/Hochfrequenz/AhbichtClient.net/blob/b234147488d95ac773d4f3942b5b1125dd4004ba/AhbichtClient/AhbichtClientQuickStartApp/Program.cs#L1-L54

This prints:
> The package '10P' is equivalent to [20] ? [244]
> 
> where '[244]' refers to 'Wenn SG10 CCI+6++ZA9 (Aggreg. verantw. ÜNB) in dieser SG8 vorhanden'
> 
> To evaluate the expression 'Muss ([1] O [2])[951]' you need to provide values for the following keys: 1, 2 and 951
> 
> The expression 'Muss ([1] O [2])[951]' is evaluated to: True

## How to use this library (Detailed)

### Prerequisites / Account
First of all, you need access to either a local instance of the [ahbicht-functions](https://github.com/Hochfrequenz/ahbicht-functions) (private repo) or use our public API.

#### Local Instance
If you have access to our docker image, check out the [docker-compose.yml](AhbichtClient/AhbichtClient.IntegrationTest/docker-compose.yml) from the integration tests to pull and start the image.

#### Public Instance
If you're just playing around, you can use our public instance at `https://ahbicht.azurewebsites.net`.
We can't guarantee uptime or performance, but it should be good enough for testing.

### Authentication

You need to provide something that implements `IAhbichtAuthenticator` to the `AhbichtClient`.
Theoretically there are two ways to authenticate, but in practice there is no authentication as of today.

#### No Authentication

If you're hosting ahbicht-function in the same network or your localhost or our public API, there is no authentication, you can use the `NoAuthenticator`.

```csharp
using AhbichtClient;
var myAuthenticator = new NoAuthenticator();
```
Its name says it all 😉 - but you still need it.

#### OAuth2 Client and Secret
If, in the future, Hochfrequenz provided you with a client Id and secret, you can use the `ClientIdClientSecretAuthenticator` class like this:

```csharp
using AhbichtClient;
var myAuthenticator = new ClientIdClientSecretAuthenticator("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET");
```

#### Base Address
The `HttpClient` instance used by the `AhbichtRestClient` class has to have a `BaseAddress` set.
Use e.g. `https://ahbicht.azurewebsites.net` for our demo system.

### Use with ASP.NET Core
This library is thought to be  primarily used in ASP.NET Core applications.
That's why it assumes that you have an `IHttpClientFactory` available in your dependency injection container.
See the [`ExampleAspNetCoreApplication/Program.cs`](AhbichtClient/ExampleAspNetCoreApplication/Program.cs) for a minimal working example.

### Use without ASP.NET Core
If you're not using ASP.NET Core, you can still use this library but setting up th `IHttpClientFactory` comes with a bit of boilerplate.
See the [`MweWithoutAspNetTest.cs`](AhbichtClient/AhbichtClient.IntegrationTest/MweWithoutAspNetTest.cs) for a minimal working example.

## Development

### Integration Tests

To run the integration test login to your docker to access the ahbicht-functions/backend image.

```bash
docker login ghcr.io -u YOUR_GITHUB_USERNAME
```

then paste your PAT similarly to described in the [integration test CI pipeline](.github/workflows/integrationtests.yml)

### Release (CI/CD)

To release a new version of this library, [create a new release](https://github.com/Hochfrequenz/AhbichtClient.net/releases/new) in GitHub.
Make sure its tag starts with `v` and the version number, e.g. `v1.2.3`.
Tags without a release won't trigger the release workflow; This enforces that you have to write a changelog before releasing.
Releases are not restricted to the main branch but we prefer them to happen there.

## Related Tools and Context
This repository is part of the [Hochfrequenz Libraries and Tools for a truly digitized market communication](https://github.com/Hochfrequenz/digital_market_communication/).

## Hochfrequenz
[Hochfrequenz Unternehmensberatung GmbH](https://www.hochfrequenz.de) is a Grünwald (near Munich) based consulting company with offices in Berlin, Leipzig, Köln and Bremen and attractive remote options.
We're not only a main contributor for open source software for German utilities but, according to [Kununu ratings](https://www.kununu.com/de/hochfrequenz-unternehmensberatung1), also among the most attractive employers within the German energy market. Applications of talented developers are welcome at any time!
Please consider visiting our [career page](https://www.hochfrequenz.de/index.php/karriere/aktuelle-stellenausschreibungen/full-stack-entwickler) (German only).
