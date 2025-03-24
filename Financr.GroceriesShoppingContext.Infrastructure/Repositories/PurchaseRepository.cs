using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Financr.GroceriesShoppingContext.Infrastructure.Repositories;

public class PurchaseRepository(WriteDbContext context) : IPurchaseRepository
{
    public async Task<Purchase?> GetPurchaseById(Guid purchaseId, CancellationToken cancellationToken = default)
    {
        return await context.Purchases.FindAsync([purchaseId], cancellationToken);
    }

    public async Task<Purchase?> CreatePurchase(Purchase purchase, CancellationToken cancellationToken = default)
    {
        var result = await context.Purchases.AddAsync(purchase, cancellationToken);

        return result.Entity;
    }

    public async Task<Purchase?> AddGrocery(Guid purchaseId, Grocery grocery, CancellationToken cancellationToken = default)
    {
        var purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id.Equals(purchaseId), cancellationToken);

        if (purchase is null) return null;
        
        purchase.AddGrocery(grocery);

        return purchase;
    }

    public async Task<Purchase?> BulkAddGrocery(Guid purchaseId, IEnumerable<Grocery> groceries, CancellationToken cancellationToken = default)
    {
        var purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id.Equals(purchaseId), cancellationToken);

        if (purchase is null) return null;
        
        purchase.SetGroceries(groceries);

        return purchase;
    }
}