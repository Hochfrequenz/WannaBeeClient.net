using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace WannaBeeClient.IntegrationTest;

/// <summary>
/// A fixture that sets up the http client factory and an injectable service collection
/// </summary>
public class ClientFixture : IClassFixture<ClientFixture>
{
    public readonly IHttpClientFactory HttpClientFactory;

    public readonly ServiceCollection ServiceCollection;

    public readonly IAhbichtAuthenticator Authenticator;

    public ClientFixture()
    {
        var services = new ServiceCollection();
        services.AddHttpClient(
            "WannaBeeClient",
            client =>
            {
                client.BaseAddress = new Uri("http://localhost:7071"); // Check docker-compose.yml
            }
        );
        var serviceProvider = services.BuildServiceProvider();
        ServiceCollection = services;
        HttpClientFactory = serviceProvider.GetService<IHttpClientFactory>()!;
        Authenticator = new NoAuthenticator(); // easy for integration tests with transformer.bee running in docker
    }
}
