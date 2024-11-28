using Core.Common;

namespace Core;

public class ProductPrice : AuditableEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public string Size { get; set; } = string.Empty;
    public double Price { get; set; }
}
