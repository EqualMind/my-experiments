using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.DataManagement.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddApplicationStorage<TService, TImplementation>(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null, 
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped, 
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        where TService : IDataStorage
        where TImplementation : DbContext, TService
    {
        services.AddDbContext<TService, TImplementation>(optionsAction, contextLifetime, optionsLifetime);
        return services;
    }

    public static IServiceCollection AddApplicationStorage<TService>(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        where TService : DbContext, IDataStorage
    {
        services.AddDbContext<TService>(optionsAction, contextLifetime, optionsLifetime);
        return services;
    }
}