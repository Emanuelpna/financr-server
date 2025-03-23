using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface IGroceryRepository
{
    Task<Grocery?> GetGroceryById(Guid groceryId, CancellationToken cancellationToken = default);
    Task<Grocery?> GetGroceryByName(string groceryName, CancellationToken cancellationToken = default);
    Task<Grocery?> GetGroceryByCode(string groceryCode, CancellationToken cancellationToken = default);
    Task<IEnumerable<Grocery>> ListGroceries(CancellationToken cancellationToken = default);

    Task<Grocery?> CreateGrocery(Grocery grocery, CancellationToken cancellationToken = default);
}