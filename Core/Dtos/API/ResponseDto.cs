using Core.Dtos.Auth;

namespace Core.Dtos.API;

public class ResponseDto
{
    public bool IsSuccessful { get; set; } = true;
    public string? Message { get; set; }
    public object? Data { get; set; }
    public List<string>? Errors { get; set; } = new();
    public string? Token { get; set; }
    public ApplicationUserDto? UserDto { get; set; }
}
