using WannaBeeClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddTransient<IAhbichtAuthenticator, NoAuthenticator>(); // Or you could use ClientIdClientSecretAuthenticator
builder.Services.AddHttpClient(
    "WannaBeeClient",
    client =>
    {
        client.BaseAddress = new Uri("http://localhost:7071/"); // or https://ahbicht.azurewebsites.net/
    }
);

// you're free to use ahbicht only for _some_ of the services it provides; Just inject the ones you need
builder.Services.AddTransient<IConditionKeyToTextResolver, WannaBeeClient.AhbichtRestClient>();
builder.Services.AddTransient<IPackageKeyToConditionResolver, WannaBeeClient.AhbichtRestClient>();
builder.Services.AddTransient<ICategorizedKeyExtractor, WannaBeeClient.AhbichtRestClient>();
builder.Services.AddTransient<IContentEvaluator, WannaBeeClient.AhbichtRestClient>();

var app = builder.Build();

app.MapGet("/", () => "I ❤ AHBicht");
app.MapGet(
    "/extractKeys",
    async (ICategorizedKeyExtractor ahbichtClient) =>
    {
        var cke = await ahbichtClient.ExtractKeys("Muss ([1] U [2] X [4])[951]");
        // this is pointless, but it shows how you can use the client
        return "Folgende Bedingungen müssen angegeben werden: "
            + string.Join(", ", cke.RequirementConstraintKeys);
    }
);
app.Run();

namespace ExampleAspNetCoreApplication
{
    public partial class Program { }
} // required for integration testing; If you miss this the test will complain, that it cannot find a 'testhost.deps.json'
