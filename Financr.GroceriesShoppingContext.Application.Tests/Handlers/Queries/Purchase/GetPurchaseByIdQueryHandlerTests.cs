using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Purchase;
using Financr.GroceriesShoppingContext.Application.Queries.Purchase;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Purchase;

public class GetPurchaseByIdQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldGetPurchaseById()
    {
        var repository = new MockPurchaseRepository();
            
        var queryHandler = new GetPurchaseByIdQueryHandler(repository);
        
        var query = new GetPurchaseByIdQuery(repository.ExistingPurchaseId);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingPurchaseId, result.Data.Purchase.Id);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetPurchaseByIdWithInvalidQueryData()
    {
        var repository = new MockPurchaseRepository();
            
        var queryHandler = new GetPurchaseByIdQueryHandler(repository);
        
        var query = new GetPurchaseByIdQuery(Guid.Empty);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("PurchaseId"));
    }
}