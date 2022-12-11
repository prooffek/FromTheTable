using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Domain.Entities;
using FromTheTable.Tests.Common.Interfaces;

namespace FromTheTable.Tests.Common.Builder;

public class IngredientBuilder : IBuilder<TestBuilder>
{
    private readonly TestBuilder _parentBuilder;
    private readonly IApplicationDbContext _context;
    private Ingredient _ingredient;

    public IngredientBuilder(TestBuilder parentBuilder, IApplicationDbContext context, Ingredient ingredient)
    {
        _parentBuilder = parentBuilder;
        _context = context;
        _ingredient = ingredient;
    }
    public TestBuilder Build()
    {
        _context.Ingredients.Add(_ingredient);
        return _parentBuilder;
    }

    public async Task<TestBuilder> BuildAsync()
    {
        await _context.Ingredients.AddAsync(_ingredient);
        return _parentBuilder;
    }
}