using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;

namespace Financr.GroceriesShoppingContext.Application.Tests.Mocks;

public class MockCategoryRepository : ICategoryRepository
{
    public Guid ExistingCategoryId { get; } = Guid.Parse("a9622516-8f9f-4db8-b3ae-85a77f9291bb");

    public string ExistingCategoryName { get; } = "Category Name";

    public Task<Category?> GetCategoryByName(string categoryName, CancellationToken cancellationToken = default)
    {
        if (categoryName != ExistingCategoryName)
            return Task.FromResult<Category?>(null);
                
        var category = new Category(ExistingCategoryId, ExistingCategoryName);

        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Category?>(null);
        
        return Task.FromResult<Category?>(category);
    }

    public Task<Category?> GetCategoryById(Guid categoryId, CancellationToken cancellationToken = default)
    {
        if (categoryId != ExistingCategoryId)
            return Task.FromResult<Category?>(null);
                
        var category = new Category(categoryId, ExistingCategoryName);

        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Category?>(null);
        
        return Task.FromResult<Category?>(category);
    }

    public Task<IEnumerable<Category>> ListCategories(CancellationToken cancellationToken = default)
    {
        var categories = new List<Category>
        {
            new (ExistingCategoryId, ExistingCategoryName)
        };
        
        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<IEnumerable<Category>>([]);

        return Task.FromResult<IEnumerable<Category>>(categories);
    }

    public Task<Category?> CreateCategory(Category category, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromResult<Category?>(null);
        
        return Task.FromResult<Category?>(category);
    }
}