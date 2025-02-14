using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Tests.Commands.Purchase;

public class AddGroceryToPurchaseCommandTests
{
    [Fact]
    public void Test_ShouldCreateAddGroceryToPurchaseCommand()
    {
        const string code = "12345";
        const string name = "Nome";
        const decimal amount = 158.53M;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 2;
     
        var purchaseId = Guid.NewGuid();
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.Empty(command.Errors);
    }
    
    [Fact]
    public void Test_ShouldNotCreateAddGroceryToPurchaseCommandWithEmptyPurchaseId()
    {
        const string code = "12345";
        const string name = "Nome";
        const decimal amount = 158.53M;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 2;
     
        var purchaseId = Guid.Empty;
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("PurchaseId"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateAddGroceryToPurchaseCommandWithEmptyCode()
    {
        const string code = "";
        const string name = "Nome";
        const decimal amount = 158.53M;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 2;
     
        var purchaseId = Guid.NewGuid();
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Code"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateAddGroceryToPurchaseCommandWithEmptyName()
    {
        const string code = "12345";
        const string name = "";
        const decimal amount = 158.53M;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 2;
     
        var purchaseId = Guid.NewGuid();
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Name"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateAddGroceryToPurchaseCommandWithInvalidAmount()
    {
        const string code = "12345";
        const string name = "Name";
        const decimal amount = 0;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 2;
     
        var purchaseId = Guid.NewGuid();
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Amount"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateAddGroceryToPurchaseCommandWithInvalidUnitType()
    {
        const string code = "12345";
        const string name = "Name";
        const decimal amount = 158.53M;
        const EGroceryUnitType unitType = (EGroceryUnitType)3;
        const decimal quantity = 2;
     
        var purchaseId = Guid.NewGuid();
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("UnitType"));
    }
    
    [Fact]
    public void Test_ShouldNotCreateAddGroceryToPurchaseCommandWithInvalidQuantity()
    {
        const string code = "12345";
        const string name = "Name";
        const decimal amount = 158.53M;
        const EGroceryUnitType unitType = EGroceryUnitType.Un;
        const decimal quantity = 0;
     
        var purchaseId = Guid.NewGuid();
        
        var command = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Quantity"));
    }
}