using Gemstone.HomeLibrary.Models;

namespace Gemstone.HomeLibrary.Services;

/// <summary>
///     Manage books in the library.
/// </summary>
public interface IBookService
{
    /// <summary>
    ///     Fetch all books from the library.
    /// </summary>
    /// <returns>An <see cref="Book" /> array of books</returns>
    ICollection<Book> GetBooks();
}
