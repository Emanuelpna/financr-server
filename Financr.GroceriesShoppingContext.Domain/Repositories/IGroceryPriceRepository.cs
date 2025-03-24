using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface IGroceryPriceRepository
{
    Task<GroceryPrice?> GetGroceryById(Guid groceryPriceId, CancellationToken cancellationToken = default);
    Task<IEnumerable<GroceryPrice>> ListGroceries(Guid groceryId, CancellationToken cancellationToken = default);

    Task<GroceryPrice?> CreateGrocery(GroceryPrice groceryPrice, CancellationToken cancellationToken = default);
}