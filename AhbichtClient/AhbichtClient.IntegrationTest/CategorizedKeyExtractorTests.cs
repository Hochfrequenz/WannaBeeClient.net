using AhbichtClient.Model;
using FluentAssertions;
using Xunit;

namespace AhbichtClient.IntegrationTest;

/// <summary>
/// Tests that keys can be extracted from an expression
/// </summary>
public class CategorizedKeyExtractorTests : IClassFixture<ClientFixture>
{
    private readonly ClientFixture _client;

    private readonly IAhbichtAuthenticator _authenticator;

    public CategorizedKeyExtractorTests(ClientFixture clientFixture)
    {
        _client = clientFixture;
        _authenticator = clientFixture.Authenticator;
    }

    [Fact]
    public async Task Keys_Can_Be_Extracted()
    {
        var httpClientFactory = _client.HttpClientFactory;
        ICategorizedKeyExtractor client = new AhbichtRestClient(httpClientFactory, _authenticator);
        var actual = await client.ExtractKeys("[2] U ([3] O [4])[901] U [555]");
        actual
            .Should()
            .BeEquivalentTo(
                new CategorizedKeyExtract
                {
                    HintKeys = new List<string> { "555" },
                    FormatConstraintKeys = new List<string> { "901" },
                    RequirementConstraintKeys = new List<string> { "2", "3", "4" },
                    PackageKeys = new List<string>(),
                    TimeConditionKeys = new List<string>(),
                }
            );
    }

    [Fact]
    public async Task Keys_Cannot_Be_Extracted()
    {
        var httpClientFactory = _client.HttpClientFactory;
        ICategorizedKeyExtractor client = new AhbichtRestClient(httpClientFactory, _authenticator);
        var creatingCategorizedKeyExtractForMalformedExpression = async () =>
            await client.ExtractKeys("[2] U [3] O [4])[901] U [555]"); // <-- contains a syntax error
        await creatingCategorizedKeyExtractForMalformedExpression
            .Should()
            .ThrowAsync<CategorizedKeyExtractError>()
            .WithMessage("*Syntax error*");
    }
}
