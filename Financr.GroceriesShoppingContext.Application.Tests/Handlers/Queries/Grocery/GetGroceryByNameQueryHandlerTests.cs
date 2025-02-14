using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Grocery;

public class GetGroceryByNameQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldGetGroceryById()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new GetGroceryByNameQueryHandler(repository);
        
        var query = new GetGroceryByNameQuery(repository.ExistingGroceryName);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingGroceryName, result.Data.Grocery.Name);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetGroceryByIdWithInvalidQueryData()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new GetGroceryByNameQueryHandler(repository);
        
        var query = new GetGroceryByNameQuery(string.Empty);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Name"));
    }
}