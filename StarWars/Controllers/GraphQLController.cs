using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWars.Core.Models;
using StarWars.Data.InMemory;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    public class GraphQLController : Controller
    {


        private IDocumentExecuter _documentExecuter;
        private ISchema _schema;


        private readonly ILogger _logger;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema, ILogger<GraphQLController> logger)
        {
    
            _logger = logger;
            _schema = schema;
            _documentExecuter = documentExecuter;
        }



        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Got request for GraphiQL. Sending GUI back");
            return View();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST 
#pragma warning disable SG0016 // Controller method is vulnerable to CSRF
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };
            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
#pragma warning restore SG0016 // Controller method is vulnerable to CSRF

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
