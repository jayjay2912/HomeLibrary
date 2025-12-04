namespace Gemstone.HomeLibrary.Dto;

/// <summary>
///     Base response object for API endpoints.
/// </summary>
public class BaseResponse
{
    public required string Message { get; set; }
}