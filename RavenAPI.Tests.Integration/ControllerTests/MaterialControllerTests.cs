using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace RavenAPI.Tests.Integration.ControllerTests;

public class MaterialControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;
    public MaterialControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }
    [Theory]
    [InlineData("RavenAPI/Material")]
    [InlineData("RavenAPI/MaterialVendor")]
    [InlineData("RavenAPI/RawMaterial")]

    public async void Test1(string url)
    {
        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode().ToString();
        Assert.Equal("text/html; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
    }
}