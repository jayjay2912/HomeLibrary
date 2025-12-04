using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Gemstone.HomeLibrary;

/// <summary>
///     Save a book to the library, or update if it already exists.
/// </summary>
public class SaveBook
{
    private readonly ILogger<SaveBook> _logger;

    public SaveBook(ILogger<SaveBook> logger)
    {
        _logger = logger;
    }

    [Function("SaveBook")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        // TODO update the book in "somewhere"

        return new JsonResult(new { Message = "SaveBook function executed successfully." });
    }
}