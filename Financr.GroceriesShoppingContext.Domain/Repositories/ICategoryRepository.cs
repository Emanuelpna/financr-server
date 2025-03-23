using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetCategoryByName(string categoryName, CancellationToken cancellationToken = default);
    Task<Category?> GetCategoryById(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> ListCategories(CancellationToken cancellationToken = default);

    Task<Category?> CreateCategory(Category category, CancellationToken cancellationToken = default);
}