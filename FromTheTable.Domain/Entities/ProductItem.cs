using FromTheTable.Domain.Entities.Base;

namespace FromTheTable.Domain.Entities;

public class ProductItem : BaseEntity
{
    public string? Name { get; set; }
    public Meal? Meal { get; set; }
    public decimal Price { get; set; }
}