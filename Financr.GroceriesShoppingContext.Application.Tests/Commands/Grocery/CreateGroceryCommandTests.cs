using Financr.GroceriesShoppingContext.Application.Commands.Grocery;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Tests.Commands.Grocery;

public class CreateGroceryCommandTests
{
    [Fact]
    public void Test_ShouldCreateGroceryCommand()
    {
        const string code = "12345";
        const string name = "Nome";
        const decimal amount = 1;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 1;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.Empty(command.Errors);
    }
    
    [Fact]
    public void Test_ShouldNotCreateGroceryCommandWithEmptyQuantity()
    {
        const string code = "12345";
        const string name = "Nome";
        const decimal amount = 1;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 0;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Quantity"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateGroceryCommandWithEmptyCode()
    {
        const string code = "";
        const string name = "Nome";
        const decimal amount = 1;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 1;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Code"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateGroceryCommandWithEmptyName()
    {
        const string code = "12345";
        const string name = "";
        const decimal amount = 1;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 1;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Name"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateGroceryCommandWithInvalidAmount()
    {
        const string code = "12345";
        const string name = "Nome";
        const decimal amount = 0;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 1;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Amount"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateGroceryCommandWithInvalidUnitType()
    {
        const string code = "12345";
        const string name = "Name";
        const decimal amount = 1;
        const EGroceryUnitType unitType = (EGroceryUnitType)3;
        const decimal quantity = 1;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("UnitType"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateGroceryCommandWithInvalidQuantity()
    {
        const string code = "12345";
        const string name = "Nome";
        const decimal amount = 1;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 0;
        
        var command = new CreateGroceryCommand(code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Quantity"));
    }
}