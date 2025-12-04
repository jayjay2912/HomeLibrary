using System.Text.Json;
using Gemstone.HomeLibrary.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Gemstone.HomeLibrary.Services;

/// <inheritdoc cref="IBookService"/>
public class BookService(IServiceProvider services, ILogger<BookService> logger) : IBookService
{
    private readonly IMemoryCache _cache = services.GetRequiredService<IMemoryCache>();

    /// <inheritdoc cref="IBookService.GetBooks"/>
    public ICollection<Book> GetBooks()
    {
        logger.LogDebug("Fetching books");

        // try and get the books from the cache first, falling back to fetching them from the original source
        var books = _cache.Get<ICollection<Book>>("books") ?? LoadBooks();

        // return the list of books we got
        return books;
    }

    /// <summary>
    ///     Load the books.
    /// </summary>
    /// <remarks>As this loads books into the cache</remarks>
    private ICollection<Book> LoadBooks()
    {
        // try and load from the book JSON data source (until we have a database backing the service, it will be readonly).
        var books = JsonSerializer
            .Deserialize<ICollection<Book>>(File.ReadAllText("books.json")) ?? new List<Book>();

        // save them to the cache for the next call
        _cache.Set("books", books);
        logger.LogDebug("Cached books");

        // return the list we now have
        return books;
    }
}
