using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Auth;

public class LoginDto
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
}
