﻿using Core.Common;

namespace Core;

public class Product : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public IEnumerable<ProductPrice> ProductPrices { get; set; }
    //public ICollection<ProductPrice> ProductPrices { get; set; }

}
