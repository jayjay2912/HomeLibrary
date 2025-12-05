using AutoMapper;
using Gemstone.HomeLibrary.Dto;
using Gemstone.HomeLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.DependencyInjection;

namespace Gemstone.HomeLibrary.Endpoints;

/// <summary>
///     Fetch books from the library.
/// </summary>
public class GetBooks(IServiceProvider services)
{
    private readonly IMapper _mapper = services.GetRequiredService<IMapper>();

    [Function("GetBooks")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
        [SqlInput(commandText: "select [Id], [Title], [Author], [ShelfLocation], [IsReadByJay], [IsReadByGemma] from dbo.Books ORDER BY [Author], [Title]",
            commandType: System.Data.CommandType.Text,
            parameters: "",
            connectionStringSetting: "DATABASE_CONNECTION_STRING")]
        IEnumerable<Book> books
        )
    {
        return new JsonResult(new BooksResponse
        {
            Message = "Books retrieved.",
            Books = _mapper.Map<List<BookDto>>(books)
        });
    }
}
