using FromTheTable.Domain.Entities.Base;

namespace FromTheTable.Domain.Entities;

public class Meal : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Recipe { get; set; }

    public IEnumerable<MealIngredient>? Ingredients { get; set; }
}