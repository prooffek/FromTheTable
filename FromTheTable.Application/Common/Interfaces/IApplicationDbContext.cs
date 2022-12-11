using FromTheTable.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FromTheTable.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Ingredient> Ingredients { get; }
    DbSet<Meal> Meals { get; }
    DbSet<MealIngredient> MealIngredients { get; }
    DbSet<Product> Products { get; }
    DbSet<ProductItem> ProductItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}