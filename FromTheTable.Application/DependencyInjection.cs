using System.Reflection;
using FromTheTable.Application.Common.Interfaces;
using FromTheTable.Application.Common.Services;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FromTheTable.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IMapper, Mapper>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}