using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExampleAspNetCoreApplication.Test;

public class ApplicationTest : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly WebApplicationFactory<Program> Factory;

    public ApplicationTest(WebApplicationFactory<Program> factory)
    {
        Factory = factory;
    }

    [Fact]
    public async Task Test_That_Setup_Works_As_Designed()
    {
        var client = Factory.CreateDefaultClient();
        var response = await client.GetAsync("/extractKeys");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Be("Folgende Bedingungen müssen angegeben werden: 1, 2, 4");
    }
}
