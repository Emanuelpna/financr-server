using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryByName(string categoryName);
    Task<Category?> GetCategoryById(Guid categoryId);
    Task<IEnumerable<Category>> ListCategories();

    Task<Category?> CreateCategory(Category category);
}