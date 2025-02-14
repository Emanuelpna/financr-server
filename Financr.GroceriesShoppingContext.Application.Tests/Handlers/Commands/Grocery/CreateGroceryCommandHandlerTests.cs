using Financr.GroceriesShoppingContext.Application.Commands.Grocery;
using Financr.GroceriesShoppingContext.Application.Handlers.Commands.Grocery;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Commands.Grocery;

public class CreateGroceryCommandHandlerTests
{
    [Fact]
    public async Task Test_ShouldCreateGrocery()
    {
        var repository = new MockGroceryRepository();
            
        var commandHandler = new CreateGroceryCommandHandler(repository);
        
        var command = new CreateGroceryCommand("12345", repository.ExistingGroceryName, 1, EGroceryUnitType.Un, 1);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
    }
    
    [Fact]
    public async Task Test_ShouldNotCreateGroceryWithInvalidCommandData()
    {
        var repository = new MockGroceryRepository();
            
        var commandHandler = new CreateGroceryCommandHandler(repository);
        
        var command = new CreateGroceryCommand("12345", repository.ExistingGroceryName, 1, EGroceryUnitType.Un, 0);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Quantity"));
    }
}