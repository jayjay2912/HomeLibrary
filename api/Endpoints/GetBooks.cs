using Gemstone.HomeLibrary.Dto;
using Gemstone.HomeLibrary.Models;
using Gemstone.HomeLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Gemstone.HomeLibrary.Endpoints;

/// <summary>
///     Fetch books from the library.
/// </summary>
public class GetBooks(IServiceProvider services)
{
    private readonly IBookService _bookService = services.GetRequiredService<IBookService>();

    [Function("GetBooks")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        var books = _bookService.GetBooks();

        return new JsonResult(new BooksResponse
        {
            Message = "Books retrieved.",
            Books = books
        });
    }
}
