namespace Gemstone.HomeLibrary.Dto;

/// <inheritdoc cref="Models.Book" />
/// <remarks>DTO representation of the <see cref="Models.Book" /></remarks>
public class BookDto
{
    /// <inheritdoc cref="Models.Book.Title" />
    public required string Title { get; init; }

    /// <inheritdoc cref="Models.Book.Author" />
    public required string Author { get; init; }

    /// <inheritdoc cref="Models.Book.ShelfLocation" />
    public string? ShelfLocation { get; set; }

    /// <inheritdoc cref="Models.Book.IsReadByJay" />
    public bool IsReadByJay { get; init; }

    /// <inheritdoc cref="Models.Book.IsReadByGemma" />
    public bool IsReadByGemma { get; init; }
}
