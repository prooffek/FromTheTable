using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FromTheTable.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Meal> Meals => Set<Meal>();
    public DbSet<MealIngredient> MealIngredients => Set<MealIngredient>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductItem> ProductItems => Set<ProductItem>();

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}