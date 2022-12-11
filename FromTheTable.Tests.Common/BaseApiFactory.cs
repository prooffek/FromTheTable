using FromTheTable.Api;
using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Persistence;
using FromTheTable.Tests.Common.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FromTheTable.Tests.Common;

public class BaseApiFactory : WebApplicationFactory<Program>
{
    private readonly IConfiguration _config;

    public BaseApiFactory(IConfiguration config)
    {
        _config = config;
    }

    protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
    {
        webHostBuilder.UseTestServer().ConfigureTestServices(MockServices);
    }

    public virtual void MockServices(IServiceCollection services)
    {
        services.Replace(ServiceDescriptor.Scoped(_ =>
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("testDb");
            var context = new ApplicationDbContext(optionsBuilder.Options);
            return context;
        }));

        services.Replace(ServiceDescriptor.Scoped<IApplicationDbContext>(serviceProvider =>
            serviceProvider.GetService<ApplicationDbContext>() ?? throw new InvalidOperationException()));

        services.Replace(ServiceDescriptor.Scoped<IDateTimeProvider>(serviceProvider =>
            serviceProvider.GetService<MockDateTimeProvider>() ?? throw new InvalidOperationException()));
    }
}