using FromTheTable.Domain.Entities.Base;

namespace FromTheTable.Domain.Entities;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public IEnumerable<ProductItem>? ProductItems { get; set; }
}