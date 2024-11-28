using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public class ProductPriceDto
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Please Select a {0}")]
    public int ProductId { get; set; }
    [Required(ErrorMessage ="Please enter a {0}")]
    public string Size { get; set; } = string.Empty;
    [Required(ErrorMessage ="Please enter a {0}")]
    [Range(1, int.MaxValue, ErrorMessage ="{0} must be greater than 0")]
    public double Price { get; set; }
}
