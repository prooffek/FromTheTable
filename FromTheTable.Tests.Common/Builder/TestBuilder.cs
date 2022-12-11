using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Domain.Entities;
using FromTheTable.Tests.Common.Interfaces;

namespace FromTheTable.Tests.Common.Builder;

public class TestBuilder : ITestBuilder
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;

    public TestBuilder(IApplicationDbContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public IngredientBuilder AddIngredient(out Ingredient ingredient)
    {
        ingredient = Entities.GetIngredientEntity();
        return new IngredientBuilder(this, _context, ingredient);
    }
    
    public void Save()
    {
        _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync(CancellationToken.None);
    }
}