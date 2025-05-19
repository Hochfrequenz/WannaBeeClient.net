[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
![Nuget Package](https://badgen.net/nuget/v/WannaBeeClient)

# WannaBeeClient.NET
A client to call endpoints of the Hochfrequenz application [wanna.bee](https://github.com/Hochfrequenz/wanna.bee) (private) in the .NET universe.
It provides you with a clean interface and strong, null-safe typing.

For this library to work you need a wanna.bee backend, with a min version v1.0.2.
A public test environment of the wanna.bee backend is available on the public internet, without warranty by Hochfrequenz.
But you can host it yourself like any other microservice.
Hochfrequenz can provide you with a standalone Docker image; Contact [@JoschaMetze](https://github.com/joschametze) (`joscha.metze+wanna.bee@hochfrequenz.de`).

## Installation

Install it from nuget [WannaBeeClient](https://www.nuget.org/packages/WannaBeeClient):

```bash
dotnet add package WannaBeeClient
```

## How to use this library (Quickstart with public backend)
We prepared minimal working examples for you to get started quickly:

* For ASP.NET checkout the [`ExampleAspNetCoreApplication`](WannaBeeClient/ExampleAspNetCoreApplication/Program.cs) project.
* For regular C# project checkout the [`WannaBeeClientQuickStartApp`](WannaBeeClient/WannaBeeClientQuickStartApp/Program.cs) project.

## How to use this library (Detailed)

### Prerequisites / Account
First of all, you need access to either a local instance of the [wanna.bee backend](https://github.com/Hochfrequenz/wanna.bee) (private repo, private docker image) or use our public API.

#### Local Instance
If you have access to our docker image, check out the [docker-compose.yml](WannaBeeClient/WannaBeeClient.IntegrationTest/docker-compose.yml) from the integration tests to pull and start the image.

#### Public Instance
If you're just playing around, you can use our public instance at `https://wannastage.utilibee.io`.
We can't guarantee uptime or performance, but it should be good enough for testing.

### Authentication

You need to provide something that implements `IWannaBeeAuthenticator` to the `WannaBeeClient`.
Theoretically there are two ways to authenticate, but in practice there is no authentication as of today.

#### No Authentication

If you're hosting wanna.bee in the same network or your localhost or our public API, there is no authentication, you can use the `NoAuthenticator`.

```csharp
using WannaBeeClient;
var myAuthenticator = new NoAuthenticator();
```
Its name says it all 😉 - but you still need it.

#### OAuth2 Client and Secret
If, in the future, Hochfrequenz provided you with a client Id and secret, you can use the `ClientIdClientSecretAuthenticator` class like this:

```csharp
using WannaBeeClient;
var myAuthenticator = new ClientIdClientSecretAuthenticator("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET");
```

#### Base Address
The `HttpClient` instance used by the `WannaBeeRestClient` class has to have a `BaseAddress` set.
Use e.g. `https://wannastage.utilibee.io` for our demo system.

### Use with ASP.NET Core
This library is thought to be  primarily used in ASP.NET Core applications.
That's why it assumes that you have an `IHttpClientFactory` available in your dependency injection container.
See the [`ExampleAspNetCoreApplication/Program.cs`](WannaBeeClient/ExampleAspNetCoreApplication/Program.cs) for a minimal working example.

### Use without ASP.NET Core
If you're not using ASP.NET Core, you can still use this library but setting up th `IHttpClientFactory` comes with a bit of boilerplate.
See the [`ValidationTests.cs`](WannaBeeClient/WannaBeeClient.IntegrationTest/ValidationTests.cs) for a minimal working example.

### Modular by Design
All the features from above are available in the `WannaBeeRestClient` class but abstracted a small interface:

https://github.com/Hochfrequenz/WannaBeeClient.net/blob/eda28aa46ec7eef6016b95f91d75ae8e857dd538/WannaBeeClient/WannaBeeClient/IEdifactAhbValidator.cs#L9-L15

This allows you to freely integrate wanna.bee with your own software.
For unit testing and mocking, these interfaces are very useful.

## Development

### Integration Tests

To run the integration test login to your docker to access both the wanna.bee backend image as well as the edifact-bo4e-converter.

```bash
docker login ghcr.io -u YOUR_GITHUB_USERNAME
```

then paste your PAT similarly to described in the [integration test CI pipeline](.github/workflows/integrationtests.yml)

### Release (CI/CD)

To release a new version of this library, [create a new release](https://github.com/Hochfrequenz/WannaBeeClient.net/releases/new) in GitHub.
Make sure its tag starts with `v` and the version number, e.g. `v1.2.3`.
Tags without a release won't trigger the release workflow; This enforces that you have to write a changelog before releasing.
Releases are not restricted to the main branch, but we prefer them to happen there.

## Related Tools and Context
This repository is part of the [Hochfrequenz Libraries and Tools for a truly digitized market communication](https://github.com/Hochfrequenz/digital_market_communication/).

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Hochfrequenz
[Hochfrequenz Unternehmensberatung GmbH](https://www.hochfrequenz.de) is a Grünwald (near Munich) based consulting company with offices in Berlin, Leipzig, Cologne and Bremen and attractive remote options.
We're not only a main contributor for open source software for German utilities but, according to [Kununu ratings](https://www.kununu.com/de/hochfrequenz-unternehmensberatung1), also among the most attractive employers within the German energy market. Applications of talented developers are welcome at any time!
Please consider visiting our [career page](https://www.hochfrequenz.de/index.php/karriere/aktuelle-stellenausschreibungen/full-stack-entwickler) (German only).
