using Core.Common;

namespace Core.BethanysPieShopHR;

public class JobCategory : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}