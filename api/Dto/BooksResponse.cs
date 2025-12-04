using Gemstone.HomeLibrary.Models;

namespace Gemstone.HomeLibrary.Dto;

/// <summary>
///     Response object for fetching books.
/// </summary>
public class BooksResponse : BaseResponse
{
    public required Book[] Books { get; set; }
}