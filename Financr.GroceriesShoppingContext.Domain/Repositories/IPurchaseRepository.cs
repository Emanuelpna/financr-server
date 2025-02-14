using Financr.GroceriesShoppingContext.Domain.Aggregates.GroceryAggregate;
using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface IPurchaseRepository
{
    Task<Purchase?> GetPurchaseById(Guid purchaseId);
    
     Task<Purchase?> CreatePurchase(Purchase purchase);
     Task<Purchase?> AddGrocery(Guid purchaseId, Grocery grocery);
     Task<Purchase?> BulkAddGrocery(Guid purchaseId, IEnumerable<Grocery> groceries);
}