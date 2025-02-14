using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Grocery;

public class ListGroceriesQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldListGroceries()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new ListGroceriesQueryHandler(repository);
        
        var query = new ListGroceriesQuery();
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
    }
}