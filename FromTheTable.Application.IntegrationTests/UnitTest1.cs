using System.Diagnostics;
using FluentAssertions;
using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Tests.Common.Builder;
using FromTheTable.Tests.Common.Mocks;

namespace FromTheTable.Application.IntegrationTests;

[TestClass]
public class UnitTest1 : Setup
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
    public async Task TestMethod1()
    {
        // arrange
        await TestBuilder
            .AddIngredient(out var ingredient)
                .BuildAsync().Result
            .SaveAsync();
        
        // assert
        var dbIngredient = Context.Ingredients.ToList();
        dbIngredient.Should().NotBeNull();
    }
}