using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Please enter a {0}")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage ="Please enter a {0}")]
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Range(1,int.MaxValue, ErrorMessage = "Please select a Category")]
    public int CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
}
