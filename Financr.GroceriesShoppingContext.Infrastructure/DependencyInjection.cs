using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Financr.GroceriesShoppingContext.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IGroceryRepository, GroceryRepository>();
        services.AddTransient<IGroceryPriceRepository, GroceryPriceRepository>();
        services.AddTransient<IPurchaseRepository, PurchaseRepository>();

        return services;
    }
}