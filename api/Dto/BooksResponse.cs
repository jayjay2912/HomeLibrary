using Gemstone.HomeLibrary.Models;

namespace Gemstone.HomeLibrary.Dto;

/// <summary>
///     Response object for fetching books.
/// </summary>
public class BooksResponse : BaseResponse
{
    /// <summary>
    ///     The full list of books in the library.
    /// </summary>
    public required ICollection<Book> Books { get; set; }
}
