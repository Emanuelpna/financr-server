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
            
        var commandHandler = new ListCategoriesQueryHandler(repository);
        
        var command = new ListCategoriesQuery();
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
    }
}