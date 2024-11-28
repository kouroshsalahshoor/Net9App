using Core.Common;

namespace Core.BethanysPieShopHR;

public class Country : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
