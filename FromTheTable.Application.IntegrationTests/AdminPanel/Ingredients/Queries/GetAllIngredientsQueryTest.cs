using FluentAssertions;
using FromTheTable.Application.AdminPanel.Ingredients.Queries.GetAllIngredients;

namespace FromTheTable.Application.IntegrationTests.AdminPanel.Ingredients.Queries;

[TestClass]
public class GetAllIngredientsQueryTest : Setup
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
    public async Task ShouldReturnEmptyListIfNoIngredientInDatabase()
    {
        // arrange
        var query = new GeAllIngredientsQuery();

        // act
        var result = await Mediator.Send(query);

        // assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [TestMethod]
    public async Task ShouldReturnAllIngredientsFromDatabase()
    {
        // arrange
        await TestBuilder
            .AddIngredient(out var ingredient1)
                .BuildAsync().Result
            .AddIngredient(out var ingredient2)
                .BuildAsync().Result
            .AddIngredient(out var ingredient3)
                .BuildAsync().Result
            .SaveAsync();

        var query = new GeAllIngredientsQuery();

        // act
        var result = await Mediator.Send(query);

        // assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(3);
        result.Any(x => x.Id == ingredient1.Id).Should().BeTrue();
        result.Any(x => x.Id == ingredient2.Id).Should().BeTrue();
        result.Any(x => x.Id == ingredient3.Id).Should().BeTrue();
    }
}