using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Financr.GroceriesShoppingContext.Infrastructure.Repositories;

public class GroceryRepository(WriteDbContext context) : IGroceryRepository
{
    public async Task<Grocery?> GetGroceryById(Guid groceryId, CancellationToken cancellationToken = default)
    {
        return await context.Groceries.FindAsync([groceryId], cancellationToken);
    }

    public async Task<Grocery?> GetGroceryByName(string groceryName, CancellationToken cancellationToken = default)
    {
        return await context.Groceries.FirstOrDefaultAsync(x => x.Name.Equals(groceryName), cancellationToken);
    }

    public async Task<Grocery?> GetGroceryByCode(string groceryCode, CancellationToken cancellationToken = default)
    {
        return await context.Groceries.FirstOrDefaultAsync(x => x.Code.Equals(groceryCode), cancellationToken);    
    }

    public async Task<IEnumerable<Grocery>> ListGroceries(CancellationToken cancellationToken = default)
    {
        return await context.Groceries.ToListAsync(cancellationToken);
    }

    public async Task<Grocery?> CreateGrocery(Grocery grocery, CancellationToken cancellationToken = default)
    {
        var result = await context.Groceries.AddAsync(grocery, cancellationToken);

        return result.Entity;
    }
}