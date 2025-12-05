namespace Gemstone.HomeLibrary.Models;

/// <summary>
///     Represents a book in the library.
/// </summary>
public class Book
{
    /// <summary>
    ///     The book title.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     The authors name.
    /// </summary>
    public required string Author { get; set; }

    /// <summary>
    ///     The shelf the book is located on.
    /// </summary>
    public string? ShelfLocation { get; set; }

    /// <summary>
    ///     Has Jay read the book.
    /// </summary>
    public bool IsReadByJay { get; set; }

    /// <summary>
    ///     Has Gemma read the book.
    /// </summary>
    public bool IsReadByGemma { get; set; }
}
