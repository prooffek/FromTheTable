using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Persistence;
using FromTheTable.Tests.Common.Builder;
using FromTheTable.Tests.Common.Interfaces;
using FromTheTable.Tests.Common.Mocks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FromTheTable.Application.IntegrationTests;

public class Setup
{
    private static readonly IConfigurationRoot Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();
    
    private bool _isInitialised;

    protected IServiceScope? TestScope;
    protected ApplicationDbContext Context;
    protected TestBuilder TestBuilder;
    protected MockDateTimeProvider? DateTimeProvider;
    protected IMediator Mediator; 

    protected DateTime Now
    {
        get => DateTimeProvider?.Now ?? DateTime.Now;
        set
        {
            if (DateTimeProvider != null) DateTimeProvider.Now = value;
        }
    }

    public virtual void SetupTests()
    {
        if (!_isInitialised)
        {
            var apiFactory = new TestApiFactory(Config);
            var scopeFactory = apiFactory.Services.GetService<IServiceScopeFactory>();

            TestScope = scopeFactory?.CreateScope();
            Context = (ApplicationDbContext) TestScope?.ServiceProvider.GetService<IApplicationDbContext>()!;
            DateTimeProvider = (MockDateTimeProvider) MockDateTimeProvider.GetInstance();
            TestBuilder = new TestBuilder(Context, DateTimeProvider);
            Mediator = TestScope?.ServiceProvider.GetService<IMediator>() ?? throw new InvalidOperationException();
        }
        
        Context?.Database.EnsureDeleted();
            
        _isInitialised = true;
    }

    public virtual void TestsCleanup()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}