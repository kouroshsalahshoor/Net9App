using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    [Required(ErrorMessage ="please enter a {0}")]
    public string Name { get; set; }
}
