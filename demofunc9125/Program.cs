using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

public static class DemoFunction
{
    [FunctionName("GetIndexHtml")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Processing request for index.html.");

        var filePath = Path.Combine("wwwroot", "index.html");
        if (File.Exists(filePath))
        {
            var content = await File.ReadAllTextAsync(filePath);
            return new ContentResult
            {
                Content = content,
                ContentType = "text/html"
            };
        }
        else
        {
            return new NotFoundResult();
        }
    }
}
