using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Commands.Purchase;

public class CreatePurchaseCommandHandlerTests
{
    [Fact]
    public async Task Test_ShouldCreatePurchase()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new CreatePurchaseCommandHandler(repository);

        const string SupermarketName = "Supermarket Name";
        
        var command = 
            new CreatePurchaseCommand(DateTimeOffset.UtcNow, SupermarketName, "123456", 1);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.NotEqual(Guid.Empty, result.Data.PurchaseId);
    }
    
    [Fact]
    public async Task Test_ShouldNotCreatePurchaseWithInvalidCommandData()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new CreatePurchaseCommandHandler(repository);
        
        var command = 
            new CreatePurchaseCommand(DateTimeOffset.UtcNow, "Supermarket Name", "123456", 0);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("TotalAmount"));
    }
}