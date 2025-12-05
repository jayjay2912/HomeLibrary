using System.Text.Json;
using Gemstone.HomeLibrary.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Gemstone.HomeLibrary.Services;

/// <inheritdoc cref="IBookService" />
public class BookService(IServiceProvider services, ILogger<BookService> logger) : IBookService
{
    private readonly IMemoryCache _cache = services.GetRequiredService<IMemoryCache>();

    /// <inheritdoc cref="IBookService.GetBooks" />
    public ICollection<Book> GetBooks()
    {
        logger.LogDebug("Fetching books");

        // try and get the books from the cache first, falling back to fetching them from the source
        var books = _cache.Get<ICollection<Book>>("books") ?? LoadBooks();

        // apply a sensible default ordering to the list
        books = books
            .OrderBy(b => b.ShelfLocation ?? "99999")
            .ThenBy(b => b.Author)
            .ThenBy(b => b.Title)
            .ToList();

        // return the list of books we got
        return books;
    }

    /// <summary>
    ///     Load the books from the underlying data source.
    /// </summary>
    private ICollection<Book> LoadBooks()
    {
        // try and load from the book JSON data source (it will be readonly until we have a database backing the service).
        var path = Environment.GetEnvironmentVariable("HOME") + @"\site\wwwroot\books.json";
        var books = JsonSerializer
            .Deserialize<ICollection<Book>>(File.ReadAllText(path)) ?? new List<Book>();

        // save them to the cache for the next call to save on disk/azure storage operations.
        _cache.Set("books", books);
        logger.LogDebug("Cached books");

        // return the list we now have
        return books;
    }
}
