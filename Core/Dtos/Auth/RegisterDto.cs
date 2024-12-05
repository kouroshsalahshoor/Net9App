using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Auth;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = default!;
    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set; } = default!;
    [Required]
    public string Role { get; set; } = default!;
}
