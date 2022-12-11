using FromTheTable.Application.AdminPanel.Ingredients.Queries.GetAllIngredients;
using FromTheTable.Application.Common.DTOs;
using FromTheTable.Application.Common.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FromTheTable.Api.Controllers.AdminPortal;

public class AdminIngredientController : ApiBaseController
{
    private readonly IMediator _mediator;

    public AdminIngredientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<IngredientDto>> GetAllIngredient()
    {
        return await _mediator.Send(new GeAllIngredientsQuery());
    }
}