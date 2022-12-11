using FromTheTable.Application.Common.DTOs;
using FromTheTable.Application.Common.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FromTheTable.Application.AdminPanel.Ingredients.Queries.GetAllIngredients;

public record GeAllIngredientsQuery : IRequest<IEnumerable<IngredientDto>>
{
}

public class GeAllIngredientsQueryHandler : IRequestHandler<GeAllIngredientsQuery, IEnumerable<IngredientDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GeAllIngredientsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<IngredientDto>> Handle(GeAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await _context.Ingredients
            .ProjectToType<IngredientDto>()
            .ToListAsync(cancellationToken);

        return ingredients;
    }
}