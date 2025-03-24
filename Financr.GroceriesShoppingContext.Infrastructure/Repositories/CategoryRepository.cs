using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Financr.GroceriesShoppingContext.Infrastructure.Repositories;

public class CategoryRepository(WriteDbContext context) : ICategoryRepository
{
    public async Task<Category?> GetCategoryById(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await context.Categories.FindAsync([categoryId], cancellationToken);
    }
    
    public async Task<Category?> GetCategoryByName(string categoryName, CancellationToken cancellationToken = default)
    {
        return await context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(categoryName), cancellationToken);
    }

    public async Task<IEnumerable<Category>> ListCategories(CancellationToken cancellationToken = default)
    {
        return await context.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category?> CreateCategory(Category category, CancellationToken cancellationToken = default)
    {
        var result = await context.Categories.AddAsync(category, cancellationToken);

        return result.Entity;
    }
}