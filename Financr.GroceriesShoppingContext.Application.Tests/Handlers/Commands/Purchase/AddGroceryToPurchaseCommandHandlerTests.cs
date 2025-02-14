using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Commands.Purchase;

public class AddGroceryToPurchaseCommandHandlerTests
{
    [Fact]
    public async Task Test_ShouldAddGroceryToPurchase()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new AddGroceryToPurchaseCommandHandler(repository);

        var command =
            new AddGroceryToPurchaseCommand(repository.ExistingPurchaseId, "12345", "GroceryName", 1, EGroceryUnitType.Un, 1);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingPurchaseId, result.Data.PurchaseId);
    }
    
    [Fact]
    public async Task Test_ShouldNotAddGroceryToPurchaseWithInvalidCommandData()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new AddGroceryToPurchaseCommandHandler(repository);

        var command =
            new AddGroceryToPurchaseCommand(repository.ExistingPurchaseId, "12345", "GroceryName", 0, EGroceryUnitType.Un, 1);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Amount"));
    }
    
      
    [Fact]
    public async Task Test_ShouldNotAddGroceryToPurchaseWithNotFoundPurchase()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new AddGroceryToPurchaseCommandHandler(repository);

        var command =
            new AddGroceryToPurchaseCommand(Guid.NewGuid(), "12345", "GroceryName", 1, EGroceryUnitType.Un, 1);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("PurchaseId"));
    }
}