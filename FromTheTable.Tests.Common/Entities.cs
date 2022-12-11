using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Domain.Entities;
using FromTheTable.Domain.Enums;
using FromTheTable.Domain.Interfaces;
using FromTheTable.Tests.Common.Mocks;

namespace FromTheTable.Tests.Common;

public static class Entities
{
    private static readonly IDateTimeProvider DateTimeProvider = MockDateTimeProvider.GetInstance();

    public static Ingredient GetIngredientEntity()
    {
        var ingredient = new Ingredient("test ingredient");

        SetCommonEntityData(ingredient);

        return ingredient;
    }
    
    public static MealIngredient GetMealIngredientEntity(Ingredient ingredient, float amountInGrams = 100)
    {
        var mealIngredient = new MealIngredient
        {
            Ingredient = ingredient,
            AmountInGrams = amountInGrams
        };
        
        SetCommonEntityData(mealIngredient);

        return mealIngredient;
    }
    
    public static MealIngredient GetMealIngredientEntity(float amountInGrams = 100)
    {
        return GetMealIngredientEntity(GetIngredientEntity(), amountInGrams);
    }

    private static void SetCommonEntityData<T>(T entity) where T : IBaseEntity<Guid>
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedOn = DateTimeProvider.Now;
        entity.ModifiedOn = entity.CreatedOn;
        entity.State = State.Active;
    }
}