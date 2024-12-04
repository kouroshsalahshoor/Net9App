using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Auth;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
    [Required]
    public string ConfirmPassword { get; set; } = default!;
    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set; } = default!;
    [Required]
    public string Role { get; set; } = default!;
}
