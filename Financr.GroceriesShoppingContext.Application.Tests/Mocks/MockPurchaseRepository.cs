using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;

namespace Financr.GroceriesShoppingContext.Application.Tests.Mocks;

public class MockPurchaseRepository : IPurchaseRepository
{
    public Guid ExistingPurchaseId { get; } = Guid.Parse("a9622516-8f9f-4db8-b3ae-85a77f9291bb");

    public Task<Purchase?> GetPurchaseById(Guid purchaseId, CancellationToken cancellationToken = default)
    {
        if (purchaseId != ExistingPurchaseId)
            return Task.FromResult<Purchase?>(null);
                
        var purchase = new Purchase(purchaseId, DateTimeOffset.UtcNow, "Name", "12345-67890", 10);

        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Purchase?>(null);
        
        return Task.FromResult<Purchase?>(purchase);
    }

    public  Task<Purchase?> CreatePurchase(Purchase purchase, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Purchase?>(null);
        
        return Task.FromResult<Purchase?>(purchase);
    }

    public  Task<Purchase?> AddGrocery(Guid purchaseId, Grocery grocery, CancellationToken cancellationToken = default)
    {
        if (purchaseId != ExistingPurchaseId)
            return Task.FromResult<Purchase?>(null);
                
        var purchase = new Purchase(purchaseId, DateTimeOffset.UtcNow, "Name", "12345-67890", 10);
        
        purchase.AddGrocery(grocery);
            
        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Purchase?>(null);
        
        return Task.FromResult<Purchase?>(purchase);
    }

    public  Task<Purchase?> BulkAddGrocery(Guid purchaseId, IEnumerable<Grocery> groceries, CancellationToken cancellationToken = default)
    {
        if (purchaseId != ExistingPurchaseId)
            return Task.FromResult<Purchase?>(null);
                
        var purchase = new Purchase(purchaseId, DateTimeOffset.UtcNow, "Name", "12345-67890", 10);
        
        purchase.SetGroceries(groceries.ToList());
            
        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Purchase?>(null);
        
        return Task.FromResult<Purchase?>(purchase);
    }
}