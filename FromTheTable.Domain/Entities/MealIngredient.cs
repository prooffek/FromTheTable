using FromTheTable.Domain.Entities.Base;
using FromTheTable.Domain.Interfaces;

namespace FromTheTable.Domain.Entities;

public class MealIngredient : BaseEntity
{
    public Ingredient? Ingredient { get; set; }
    public float AmountInGrams { get; set; }

    public Meal? Meal { get; set; }
}