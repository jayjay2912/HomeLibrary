using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gemstone.HomeLibrary.Dto;
using Gemstone.HomeLibrary.Models;

namespace Gemstone.HomeLibrary;

/// <summary>
///     Fetch books from the library.
/// </summary>
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
        _logger.LogInformation("Fetching books");

        // TODO fetch books from "somewhere"
        Book[] books = [
            new() { Title = "A Wrinkle in Time" },
            new() { Title = "The Hobbit" },
            new() { Title = "Hyperion" },
        ];

        return new JsonResult(new BooksResponse
        {
            Message = "Books retrieved successfully",
            Books = books
        });
    }
}