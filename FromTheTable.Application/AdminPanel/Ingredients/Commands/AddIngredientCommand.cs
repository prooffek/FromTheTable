using FromTheTable.Application.Common.DTOs;
using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Domain.Entities;
using MediatR;

namespace FromTheTable.Application.AdminPanel.Ingredients.Commands;

public record AddIngredientCommand : IRequest
{
    public string Name { get; set; }
}

public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand>
{
    private readonly IApplicationDbContext _context;

    public AddIngredientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredient = new Ingredient(request.Name);

        await _context.Ingredients.AddAsync(ingredient, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}