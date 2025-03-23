using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface IPurchaseRepository
{ 
     Task<Purchase?> GetPurchaseById(Guid purchaseId, CancellationToken cancellationToken = default);
    
     Task<Purchase?> CreatePurchase(Purchase purchase, CancellationToken cancellationToken = default);
     
     Task<Purchase?> AddGrocery(Guid purchaseId, Grocery grocery, CancellationToken cancellationToken = default);
     
     Task<Purchase?> BulkAddGrocery(Guid purchaseId, IEnumerable<Grocery> groceries, CancellationToken cancellationToken = default);
}
