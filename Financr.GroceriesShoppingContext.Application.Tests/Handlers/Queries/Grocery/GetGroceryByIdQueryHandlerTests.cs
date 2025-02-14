using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Grocery;

public class GetGroceryByIdQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldGetGroceryById()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new GetGroceryByIdQueryHandler(repository);
        
        var query = new GetGroceryByIdQuery(repository.ExistingGroceryId);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingGroceryId, result.Data.Grocery.Id);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetGroceryByIdWithInvalidQueryData()
    {
        var repository = new MockGroceryRepository();
            
        var queryHandler = new GetGroceryByIdQueryHandler(repository);
        
        var query = new GetGroceryByIdQuery(Guid.Empty);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("GroceryId"));
    }
}