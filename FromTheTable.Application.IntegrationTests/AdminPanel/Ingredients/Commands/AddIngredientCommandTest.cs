using FluentAssertions;
using FromTheTable.Application.AdminPanel.Ingredients.Commands;
using Microsoft.EntityFrameworkCore;

namespace FromTheTable.Application.IntegrationTests.AdminPanel.Ingredients.Commands;

[TestClass]
public class AddIngredientCommandTest : Setup
{
    [TestInitialize]
    public void Setup()
    {
        SetupTests();
    }

    [TestCleanup]
    public void Cleanup()
    {
        TestsCleanup();
    }

    [TestMethod]
    public async Task ShouldAddIngredientToDatabase()
    {
        // arrange
        const string ingredientName = "potato";
        var command = new AddIngredientCommand { Name = ingredientName };
        
        // act
        await Mediator.Send(command);
        
        // assert
        var ingredient = await Context.Ingredients.FirstOrDefaultAsync(x => x.Name == ingredientName);
        ingredient.Should().NotBeNull();
    }
}