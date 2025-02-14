using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Commands.Purchase;

public class BulkAddGroceryToPurchaseCommandHandlerTests
{
    [Fact]
    public async Task Test_ShouldBulkAddGroceriesToPurchase()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new BulkAddGroceryToPurchaseCommandHandler(repository);

        var groceries = new List<BulkAddGroceryToPurchaseCommandItem>
        {
           new("12345", "Grocery 1", 1, EGroceryUnitType.Un, 1),
           new("67890", "Grocery 2", 1, EGroceryUnitType.Un, 1),
        };
        
        var command = new BulkAddGroceryToPurchaseCommand(repository.ExistingPurchaseId, groceries);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingPurchaseId, result.Data.PurchaseId);
    }
    
    [Fact]
    public async Task Test_ShouldNotBulkAddGroceriesToPurchaseWithEmptyGroceriesList()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new BulkAddGroceryToPurchaseCommandHandler(repository);

        var groceries = new List<BulkAddGroceryToPurchaseCommandItem>
        {
        };
        
        var command = new BulkAddGroceryToPurchaseCommand(repository.ExistingPurchaseId, groceries);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Groceries"));
    }
    
    [Fact]
    public async Task Test_ShouldNotBulkAddGroceriesToPurchaseWithInvalidCommandDataInOneItem()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new BulkAddGroceryToPurchaseCommandHandler(repository);

        var groceries = new List<BulkAddGroceryToPurchaseCommandItem>
        {
            new("12345", "Grocery 1", 1, EGroceryUnitType.Un, 1),
            new("67890", "Grocery 2", 0, EGroceryUnitType.Un, 1),
        };
        
        var command = new BulkAddGroceryToPurchaseCommand(repository.ExistingPurchaseId, groceries);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Amount"));
    }
    
      
    [Fact]
    public async Task Test_ShouldNotBulkAddGroceriesToPurchaseWithRepeatedCommandItem()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new BulkAddGroceryToPurchaseCommandHandler(repository);

        var groceries = new List<BulkAddGroceryToPurchaseCommandItem>
        {
            new("12345", "Grocery 1", 1, EGroceryUnitType.Un, 1),
            new("12345", "Grocery 2", 1, EGroceryUnitType.Un, 1),
        };
        
        var command = new BulkAddGroceryToPurchaseCommand(repository.ExistingPurchaseId, groceries);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(1, result.Data.GroceriesAdded);
    }
    
    [Fact]
    public async Task Test_ShouldNotBulkAddGroceriesToPurchaseWithNotFoundPurchase()
    {
        var repository = new MockPurchaseRepository();
            
        var commandHandler = new BulkAddGroceryToPurchaseCommandHandler(repository);

        var groceries = new List<BulkAddGroceryToPurchaseCommandItem>
        {
            new("12345", "Grocery 1", 1, EGroceryUnitType.Un, 1),
            new("67890", "Grocery 2", 1, EGroceryUnitType.Un, 1),
        };
        
        var command = new BulkAddGroceryToPurchaseCommand(Guid.NewGuid(), groceries);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("PurchaseId"));
    }
}