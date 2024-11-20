using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Please enter a {0}")]
    public string Name { get; set; } = string.Empty;
}
