using Financr.GroceriesShoppingContext.Domain.Aggregates.GroceryAggregate;
using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.Repositories;

namespace Financr.GroceriesShoppingContext.Application.Tests.Mocks;

public class MockGroceryRepository : IGroceryRepository
{
    public Guid ExistingGroceryId { get; } = Guid.Parse("a9622516-8f9f-4db8-b3ae-85a77f9291bb");
    
    public string ExistingGroceryName { get; } = "Grocery Name";
    
    public string ExistingGroceryCode { get; } = "12345";
    
    public Task<Grocery?> GetGroceryById(Guid groceryId)
    {
        if (groceryId != ExistingGroceryId)
            return Task.FromResult<Grocery?>(null);
                
        var grocery = new Grocery(ExistingGroceryId, "12345", ExistingGroceryName, 1, 1, EGroceryUnitType.Un);

        return Task.FromResult<Grocery?>(grocery);
    }

    public Task<Grocery?> GetGroceryByName(string groceryName)
    {
        if (groceryName != ExistingGroceryName)
            return Task.FromResult<Grocery?>(null);
                
        var grocery = new Grocery("12345", ExistingGroceryName, 1, 1, EGroceryUnitType.Un);

        return Task.FromResult<Grocery?>(grocery);
    }

    public Task<Grocery?> GetGroceryByCode(string groceryCode)
    {
        if (groceryCode != ExistingGroceryCode)
            return Task.FromResult<Grocery?>(null);
                
        var grocery = new Grocery("12345", ExistingGroceryCode, 1, 1, EGroceryUnitType.Un);

        return Task.FromResult<Grocery?>(grocery);
    }

    public Task<IEnumerable<Grocery>> ListGroceries()
    {
        var groceries = new List<Grocery>
        {
            new (ExistingGroceryId, "12345", ExistingGroceryName, 1, 1, EGroceryUnitType.Un)
        };

        return Task.FromResult<IEnumerable<Grocery>>(groceries);
    }

    public Task<Grocery?> CreateGrocery(Grocery grocery)
    {
        return Task.FromResult<Grocery?>(grocery);
    }
}