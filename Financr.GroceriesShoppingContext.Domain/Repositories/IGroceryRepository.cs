using Financr.GroceriesShoppingContext.Domain.Aggregates.GroceryAggregate;
using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface IGroceryRepository
{
    Task<Grocery?> GetGroceryById(Guid groceryId);
    Task<Grocery?> GetGroceryByName(string groceryName);
    Task<IEnumerable<Grocery>> ListGroceries();

    Task<Grocery?> CreateGrocery(Grocery grocery);
}