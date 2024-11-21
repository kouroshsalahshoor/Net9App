namespace Domain;

public class ProductPrice
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public string Size { get; set; } = string.Empty;
    public double Price { get; set; }
}
