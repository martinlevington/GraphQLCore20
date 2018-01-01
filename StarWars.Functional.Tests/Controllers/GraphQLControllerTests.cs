using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace StarWars.Functional.Tests.Controllers
{
    public class GraphQLControllerTests
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GraphQLControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
              //  .UseEnvironment("Test")
                .UseStartup<StartupTest>()
            );
            _client = _server.CreateClient();
        }

        [Fact]
        public async void ReturnR2D2Droid()
        {
            // Given
            var query = @"{
                ""query"": ""query { hero { id name } }""
            }";
            var content = new StringContent(query, Encoding.UTF8, "application/json");

            // When
            var response = await _client.PostAsync("/api/graphql", content);

            // Then
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("R2-D2", responseString);
        }
    }
}
