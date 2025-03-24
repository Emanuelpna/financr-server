using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Financr.GroceriesShoppingContext.Infrastructure.Repositories;

public class GroceryPriceRepository(WriteDbContext context) : IGroceryPriceRepository
{
    public async Task<GroceryPrice?> GetGroceryById(Guid groceryPriceId, CancellationToken cancellationToken = default)
    {
        return await context.GroceryPrices.FindAsync([groceryPriceId], cancellationToken);
    }

    public async Task<IEnumerable<GroceryPrice>> ListGroceries(Guid groceryId, CancellationToken cancellationToken = default)
    {
        return await context.GroceryPrices.Where(x => x.GroceryId.Equals(groceryId)).ToListAsync(cancellationToken);
    }

    public async Task<GroceryPrice?> CreateGrocery(GroceryPrice groceryPrice, CancellationToken cancellationToken = default)
    {
        var result = await context.AddAsync(groceryPrice, cancellationToken);

        return result.Entity;
    }
}