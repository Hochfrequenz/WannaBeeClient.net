using FluentAssertions;
using WannaBeeClient.Model;
using Xunit;

namespace WannaBeeClient.IntegrationTest;

/// <summary>
/// Tests that edifact messages can be validated
/// </summary>
public class ValidationTests : IClassFixture<ClientFixture>
{
    private const string Valid44042 = """
UNB+UNOC:3+9910902000001:500+9900269000000:500+241204:0617+ALEXANDE121116'
UNH+ALEXANDE846768+UTILMD:D:11A:UN:S1.1'
BGM+E01+ALEXANDE846768BGM'
DTM+137:202412040617?+00:303'
NAD+MS+9910902000001::293'
NAD+MR+9900269000000::293'
IDE+24+ALEXANDE307337741'
DTM+76:202412162300?+00:303'
STS+7++E03'
AGR+9:Z04'
LOC+Z16+58397694242'
LOC+Z17+DE69617355664H850VEVXMWUXGZ1R0MKP'
RFF+Z13:55042'
NAD+Z07+++Muster:Max:::Herr:Z01'
NAD+Z08+++Muster:Max:::Herr:Z01+Am Ihmeufer::201+Hannover++30149+DE'
NAD+Z05+++Muster:Max:::Herr:Z01+Am Ihmeufer::201+Hannover++30149+DE'
RFF+Z19:DE69617355664H850VEVXMWUXGZ1R0MKP'
UNT+20+ALEXANDE846768'
UNZ+1+ALEXANDE121116'
""";

    private const string Invalid44042 = // Wrong STS value 'Hallo'
        """
UNB+UNOC:3+9910902000001:500+9900269000000:500+241204:0617+ALEXANDE121116'
UNH+ALEXANDE846768+UTILMD:D:11A:UN:S1.1'
BGM+E01+ALEXANDE846768BGM'
DTM+137:202412040617?+00:303'
NAD+MS+9910902000001::293'
NAD+MR+9900269000000::293'
IDE+24+ALEXANDE307337741'
DTM+76:202412162300?+00:303'
STS+7++HALLO'
AGR+9:Z04'
LOC+Z16+58397694242'
LOC+Z17+DE69617355664H850VEVXMWUXGZ1R0MKP'
RFF+Z13:55042'
NAD+Z07+++Muster:Max:::Herr:Z01'
NAD+Z08+++Muster:Max:::Herr:Z01+Am Ihmeufer::201+Hannover++30149+DE'
NAD+Z05+++Muster:Max:::Herr:Z01+Am Ihmeufer::201+Hannover++30149+DE'
RFF+Z19:DE69617355664H850VEVXMWUXGZ1R0MKP'
UNT+20+ALEXANDE846768'
UNZ+1+ALEXANDE121116'
""";
    private readonly ClientFixture _client;

    private readonly IWannaBeeAuthenticator _authenticator;

    public ValidationTests(ClientFixture clientFixture)
    {
        _client = clientFixture;
        _authenticator = clientFixture.Authenticator;
    }

    [Fact]
    public async Task Successful_Validations_Work_As_Expected()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IEdifactAhbValidator client = new WannaBeeRestClient(httpClientFactory, _authenticator);

        var actual = await client.Validate(
            new ValidateEdifactRequest(Edifact: Valid44042, IncludeBoneycombPaths: false)
        );
        actual.Should().BeAssignableTo<PositiveValidationResponse>();
    }

    [Fact]
    public async Task Errornous_Validations_Work_As_Expected()
    {
        var httpClientFactory = _client.HttpClientFactory;
        IEdifactAhbValidator client = new WannaBeeRestClient(httpClientFactory, _authenticator);

        var actual = await client.Validate(
            new ValidateEdifactRequest(Edifact: Invalid44042, IncludeBoneycombPaths: false)
        );
        actual
            .Should()
            .BeAssignableTo<NegativeValidationResponse>()
            .And.Subject.As<NegativeValidationResponse>()
            .Errors.Should()
            .HaveCount(((NegativeValidationResponse)actual).NumErrors);
    }
}
