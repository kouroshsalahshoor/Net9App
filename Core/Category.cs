using Core.Common;

namespace Core;

public class Category : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
