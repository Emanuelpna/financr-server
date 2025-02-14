using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Grocery;

public class GetGroceryByCodeQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldGetGroceryByCode()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new GetGroceryByCodeQueryHandler(repository);
        
        var query = new GetGroceryByCodeQuery(repository.ExistingGroceryCode);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingGroceryCode, result.Data.Grocery.Code);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetGroceryByCodeWithInvalidQueryData()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new GetGroceryByCodeQueryHandler(repository);
        
        var query = new GetGroceryByCodeQuery(string.Empty);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Code"));
    }
}