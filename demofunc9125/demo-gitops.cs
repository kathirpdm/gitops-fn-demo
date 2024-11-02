using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Demo.Function
{
    public class demo_gitops
    {
        private readonly ILogger<demo_gitops> _logger;

        public demo_gitops(ILogger<demo_gitops> logger)
        {
            _logger = logger;
        }

        [Function("demo_gitops")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Admin, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
