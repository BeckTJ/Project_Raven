using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace RavenAPI.Tests.Integration;

public class MaterialControllerTests
{
    private readonly TestServer _server;
    private readonly HttpClient _client;
    public MaterialControllerTests()
    {
        _server = new TestServer(new WebHostBuilder().UseStartup<Program>());
        _client = _server.CreateClient();
    }
    [Fact]
    public async void Test1()
    {
        var responce = await _client.GetAsync("/");
        responce.EnsureSuccessStatusCode();
        var responceString = await responce.Content.ReadAsStringAsync();

        Assert.Equal("Hello World!", responceString);
    }
}