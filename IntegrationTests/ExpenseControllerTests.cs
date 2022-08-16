using ControleFinanceiro.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class ExpenseControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ExpenseControllerTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.Equals("Hello World!", responseString);
        }
    }

    //public class ExpenseControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    //{
    //    private readonly WebApplicationFactory<Startup> _factory;

    //    public ExpenseControllerTests(WebApplicationFactory<Startup> factory)
    //    {
    //        _factory = factory;
    //    }

    //    [Theory]
    //    [InlineData("/")]
    //    [InlineData("/Index")]
    //    [InlineData("/About")]
    //    [InlineData("/Privacy")]
    //    [InlineData("/Contact")]
    //    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    //    {
    //        // Arrange
    //        var client = _factory.CreateClient();

    //        // Act
    //        var response = await client.GetAsync(url);

    //        // Assert
    //        response.EnsureSuccessStatusCode(); // Status Code 200-299
    //        Assert.Equals("text/html; charset=utf-8",
    //            response.Content.Headers.ContentType.ToString());
    //    }
    //}
}
