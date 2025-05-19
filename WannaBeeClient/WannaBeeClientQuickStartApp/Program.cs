using WannaBeeClient;
using WannaBeeClient.Model;

namespace WannaBeeClientQuickStartApp;

public class MyHttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name)
    {
        return new HttpClient { BaseAddress = new Uri("https://wannastage.utilibee.io") };
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var client = new WannaBeeRestClient(new MyHttpClientFactory(), new NoAuthenticator());

        const string valid44042 = """
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
        var validationResponse = await client.Validate(
            new ValidateEdifactRequest(Edifact: valid44042, IncludeBoneycombPaths: false)
        );
        Console.WriteLine(
            $"The edifact '{valid44042[..20]}...' is {((validationResponse is PositiveValidationResponse) ? "valid" : "invalid")}"
        );
    }
}
