using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AhbichtClient.IntegrationTest;

/// <summary>
/// Tests that a connection to the API can be established
/// </summary>
public class ConnectionTests : IClassFixture<ClientFixture>
{
    private readonly ClientFixture _client;
    private readonly IAhbichtAuthenticator _authenticator;

    public ConnectionTests(ClientFixture clientFixture)
    {
        _client = clientFixture;
        _authenticator = clientFixture.Authenticator;
    }

    [Fact]
    public async Task IsAvailable_Returns_True_If_Service_Is_Available()
    {
        var httpClientFactory = _client.HttpClientFactory;
        var client = new AhbichtRestClient(httpClientFactory, _authenticator);
        var result = await client.IsAvailable();
        result.Should().BeTrue();
    }

    [Fact]
    public async Task IsAvailable_Throws_Exception_If_Host_Is_Unavailable()
    {
        var services = new ServiceCollection();
        services.AddHttpClient(
            "AhbichtClient",
            client =>
            {
                client.BaseAddress = new Uri("http://localhost:1234"); // <-- no service running under this address
            }
        );
        var serviceProvider = services.BuildServiceProvider();
        var client = new AhbichtRestClient(
            serviceProvider.GetService<IHttpClientFactory>()!,
            _authenticator
        );
        var checkIfIsAvailable = async () => await client.IsAvailable();
        await checkIfIsAvailable.Should().ThrowAsync<HttpRequestException>();
    }
}
