using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StarWars.Controllers;
using StarWars.Core.Models;
using Xunit;

namespace StarWars.Unit.Tests.Controllers
{
    public class GraphQLControllerTests
    {

        private readonly GraphQLController _graphqlController;

        public GraphQLControllerTests()
        {
            // Given
            var documentExecutor = new Mock<IDocumentExecuter>();
            documentExecutor.Setup(x => x.ExecuteAsync(It.IsAny<ExecutionOptions>())).Returns(Task.FromResult(new ExecutionResult()));
            var schema = new Mock<ISchema>();
            _graphqlController = new GraphQLController(documentExecutor.Object, schema.Object, new Mock<ILogger<GraphQLController>>().Object);
        }

        [Fact]
        public void ReturnNotNullViewResult()
        {
            // When
            var result = _graphqlController.Get() as ViewResult;

            // Then
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task ReturnNotNullExecutionResult()
        {
            // Given
            var query = new GraphQLQuery { Query = @"{ ""query"": ""query { hero { id name } }""" };

            // When
            var result = await _graphqlController.Post(query);

            // Then
            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var executionResult = okObjectResult.Value;
            Assert.NotNull(executionResult);
        }
    }
}
