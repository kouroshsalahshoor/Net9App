using Core.Dtos.Auth;

namespace Core.Dtos.API;

public class ResponseDto
{
    public bool IsSuccessful { get; set; } = true;
    public string? Message { get; set; }
    public object? Data { get; set; }
    public IEnumerable<string>? Errors { get; set; }
    public string? Token { get; set; }
    public ApplicationUserDto? UserDto { get; set; }
}
