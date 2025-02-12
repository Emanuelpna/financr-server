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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.Empty(sut.Errors);
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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("PurchaseId", sut.Errors[0].Field);
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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("Code", sut.Errors[0].Field);
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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("Name", sut.Errors[0].Field);
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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("Amount", sut.Errors[0].Field);
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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("UnitType", sut.Errors[0].Field);
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
        
        var sut = new AddGroceryToPurchaseCommand(purchaseId, code, name, amount, unitType, quantity);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("Quantity", sut.Errors[0].Field);
    }
}