using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Gemstone.HomeLibrary;

public class GetBooks
{
    private readonly ILogger<GetBooks> _logger;

    public GetBooks(ILogger<GetBooks> logger)
    {
        _logger = logger;
    }

    [Function("GetBooks")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}