using WannaBeeClient;
using WannaBeeClient.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddTransient<IWannaBeeAuthenticator, NoAuthenticator>(); // Or you could use ClientIdClientSecretAuthenticator
builder.Services.AddHttpClient(
    "WannaBeeClient",
    client =>
    {
        client.BaseAddress = new Uri("http://localhost:7071/"); // or https://wannastage.utilibee.io/
    }
);

// you can inject a mock if necessary
builder.Services.AddTransient<IEdifactAhbValidator, WannaBeeRestClient>();

var app = builder.Build();

app.MapGet("/", () => "I ❤ wanna.bee");
app.MapGet(
    "/validate",
    async (IEdifactAhbValidator wannabeeClient) =>
    {
        // IRL you'd of course not hardcode the message but get it from a request
        const string invalidMessage = """
UNB+UNOC:3+9910902000001:500+9900269000000:500+241204:0617+ALEXANDE121116'
UNH+ALEXANDE846768+UTILMD:D:11A:UN:S1.1'
BGM+E01+ALEXANDE846768BGM'
DTM+137:202412040617?+00:303'
NAD+MS+9910902000001::293'
NAD+MR+9900269000000::293'
IDE+24+ALEXANDE307337741'
DTM+76:202412162300?+00:303'
STS+7++DAS HIER IST AUF KEINEN FALL valide'
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
        var validationResponse = await wannabeeClient.Validate(
            new ValidateEdifactRequest(Edifact: invalidMessage, IncludeBoneycombPaths: false)
        );
        return validationResponse switch
        {
            PositiveValidationResponse _ => new Dictionary<string, string>
            {
                { "Status", "Positive" },
                { "Message", "hurray" },
            },
            NegativeValidationResponse negativeValidationResponse => new Dictionary<string, string>
            {
                { "Status", "Negative" },
                { "Message", "boooh" },
                {
                    "Details",
                    string.Join(", ", negativeValidationResponse.Errors.Select(x => x.Description))
                },
            },
            _ => throw new NotFiniteNumberException("Unknown validation response"),
        };
    }
);
app.Run();

namespace ExampleAspNetCoreApplication
{
    public partial class Program { }
} // required for integration testing; If you miss this the test will complain, that it cannot find a 'testhost.deps.json'
