namespace Core.Dtos.Auth;

public class ApplicationUserDto
{
    public string Id { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Role { get; set; } = default!;
    //public string? Token { get; set; } 
    //public int ExpiresIn { get; set; } 
    //public DateTime ExpireyTimeStamp { get; set; } 
}
