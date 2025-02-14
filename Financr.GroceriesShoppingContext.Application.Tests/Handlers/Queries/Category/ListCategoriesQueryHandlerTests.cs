using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Category;

public class ListCategoriesQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldListCategories()
    {
        var repository = new MockCategoryRepository();
            
        var queryHandler = new ListCategoriesQueryHandler(repository);
        
        var query = new ListCategoriesQuery();
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
    }
}