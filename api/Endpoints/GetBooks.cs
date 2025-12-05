using AutoMapper;
using Gemstone.HomeLibrary.Dto;
using Gemstone.HomeLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;

namespace Gemstone.HomeLibrary.Endpoints;

/// <summary>
///     Fetch books from the library.
/// </summary>
public class GetBooks(IServiceProvider services)
{
    private readonly IBookService _bookService = services.GetRequiredService<IBookService>();
    private readonly IMapper _mapper = services.GetRequiredService<IMapper>();

    [Function("GetBooks")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        var books = _bookService.GetBooks();

        return new JsonResult(new BooksResponse
        {
            Message = "Books retrieved.",
            Books = _mapper.Map<List<BookDto>>(books)
        });
    }
}
