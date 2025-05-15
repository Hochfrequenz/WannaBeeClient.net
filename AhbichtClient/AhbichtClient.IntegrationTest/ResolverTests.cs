using AhbichtClient.Model;
using EDILibrary;
using FluentAssertions;
using Xunit;

namespace AhbichtClient.IntegrationTest;

/// <summary>
/// Tests that packages and conditions can be resolved
/// </summary>
public class ResolverTests : IClassFixture<ClientFixture>
{
    private readonly ClientFixture _client;

    private readonly IAhbichtAuthenticator _authenticator;

    public ResolverTests(ClientFixture clientFixture)
    {
        _client = clientFixture;
        _authenticator = clientFixture.Authenticator;
    }

    [Fact]
    public async Task Packages_Can_Be_Resolved()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IPackageKeyToConditionResolver client = new AhbichtRestClient(
            httpClientFactory,
            _authenticator
        );
        var actual = await client.ResolvePackage(
            "10P",
            EdifactFormat.UTILMD,
            EdifactFormatVersion.FV2210
        );
        actual.Should().NotBeNull();
        actual.PackageExpression.Should().Be("[20] \u2227 [244]"); // [20] ∧ [244]
    }

    [Fact]
    public async Task Packages_Cannot_Be_Resolved()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IPackageKeyToConditionResolver client = new AhbichtRestClient(
            httpClientFactory,
            _authenticator
        );
        var resolvingUnknownPackages = async () =>
            await client.ResolvePackage("123P", EdifactFormat.UTILMD, EdifactFormatVersion.FV2210);
        await resolvingUnknownPackages.Should().ThrowAsync<PackageNotResolvableException>();
    }

    [Fact]
    public async Task Conditions_Can_Be_Resolved()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IConditionKeyToTextResolver client = new AhbichtRestClient(
            httpClientFactory,
            _authenticator
        );
        var actual = await client.ResolveCondition(
            "10",
            EdifactFormat.UTILMD,
            EdifactFormatVersion.FV2210
        );
        actual.Should().NotBeNull();
        actual
            .ConditionText.Should()
            .Be("Wenn SG4 STS+Z17 (Transaktionsgrund für befristete Anmeldung) vorhanden");
    }

    [Fact]
    public async Task Conditions_Cannot_Be_Resolved()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IConditionKeyToTextResolver client = new AhbichtRestClient(
            httpClientFactory,
            _authenticator
        );
        var resolvingUnknownPackages = async () =>
            await client.ResolveCondition(
                "7890",
                EdifactFormat.UTILMD,
                EdifactFormatVersion.FV2210
            );
        await resolvingUnknownPackages.Should().ThrowAsync<ConditionNotResolvableException>();
    }
}
