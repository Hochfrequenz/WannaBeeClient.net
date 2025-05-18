using EDILibrary;
using Xunit;

namespace WannaBeeClient.IntegrationTest;

/// <summary>
/// A minimal working example on how to use this library without ASP.NET
/// </summary>
public class MweWithoutAspNetTest
{
    /// <summary>
    /// in asp.net applications, there's a service collection that is used to create the http client factory for you
    /// </summary>
    internal class MyHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient
            {
                BaseAddress = new Uri("http://localhost:7071"), // or use "http://ahbicht.azurewebsites.net
            };
        }
    }

    [Fact]
    public async Task Test_Ahbicht_Communication()
    {
        IHttpClientFactory myFactory = new MyHttpClientFactory();
        IAhbichtAuthenticator myAuthenticator = new NoAuthenticator(); // or use ClientIdClientSecretAuthenticator
        var client = new AhbichtRestClient(myFactory, myAuthenticator);
        await client.ResolvePackage("10P", EdifactFormat.UTILMD, EdifactFormatVersion.FV2404);
    }
}
