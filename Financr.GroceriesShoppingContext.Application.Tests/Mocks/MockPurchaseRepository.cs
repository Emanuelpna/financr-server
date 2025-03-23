using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;

namespace Financr.GroceriesShoppingContext.Application.Tests.Mocks;

public class MockPurchaseRepository : IPurchaseRepository
{
    public Guid ExistingPurchaseId { get; } = Guid.Parse("a9622516-8f9f-4db8-b3ae-85a77f9291bb");

    public Task<Purchase?> GetPurchaseById(Guid purchaseId)
    {
        if (purchaseId != ExistingPurchaseId)
            return Task.FromResult<Purchase?>(null);
                
        var purchase = new Purchase(purchaseId, DateTimeOffset.UtcNow, "Name", "12345-67890", 10);

        return Task.FromResult<Purchase?>(purchase);
    }

    public  Task<Purchase?> CreatePurchase(Purchase purchase)
    {
        return Task.FromResult<Purchase?>(purchase);
    }

    public  Task<Purchase?> AddGrocery(Guid purchaseId, Grocery grocery)
    {
        if (purchaseId != ExistingPurchaseId)
            return Task.FromResult<Purchase?>(null);
                
        var purchase = new Purchase(purchaseId, DateTimeOffset.UtcNow, "Name", "12345-67890", 10);
        
        purchase.AddGrocery(grocery);
            
        return Task.FromResult<Purchase?>(purchase);
    }

    public  Task<Purchase?> BulkAddGrocery(Guid purchaseId, IEnumerable<Grocery> groceries)
    {
        if (purchaseId != ExistingPurchaseId)
            return Task.FromResult<Purchase?>(null);
                
        var purchase = new Purchase(purchaseId, DateTimeOffset.UtcNow, "Name", "12345-67890", 10);
        
        purchase.SetGroceries(groceries.ToList());
            
        return Task.FromResult<Purchase?>(purchase);
    }
}