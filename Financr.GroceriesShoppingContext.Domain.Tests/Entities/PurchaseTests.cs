using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Domain.Tests.Entities;

public class PurchaseTests
{
    [Fact]
    public void Test_ShouldAddNewGrocery()
    {
        const string supermaketName = "Supermarket Name";
        const string nfeKey = "f61e2395-b9f2-4035-aba0-8369b73d6b9c";
        const decimal totalAmount = 180.94M;
        
        var purchaseDate = DateTimeOffset.UtcNow.AddHours(-2);
        
        var sut = new Purchase(purchaseDate, supermaketName, nfeKey, totalAmount);

        var grocery = new Grocery("03981029", "Shampoo", 15.80m, 1M, EGroceryUnitType.Un);
        
        sut.AddGrocery(grocery);

        Assert.Contains(sut.Groceries, x => x.Code.Equals(grocery.Code));
    }
    
    [Fact]
    public void Test_ShouldNotAddRepeatedGrocery()
    {
        const string supermaketName = "Supermarket Name";
        const string nfeKey = "f61e2395-b9f2-4035-aba0-8369b73d6b9c";
        const decimal totalAmount = 180.94M;
        
        var purchaseDate = DateTimeOffset.UtcNow.AddHours(-2);
        
        var sut = new Purchase(purchaseDate, supermaketName, nfeKey, totalAmount);

        var grocery = new Grocery("03981029", "Shampoo", 15.80m, 1M, EGroceryUnitType.Un);
        
        sut.AddGrocery(grocery);
        
        sut.AddGrocery(grocery);

        Assert.Single(sut.Groceries, x => x.Code.Equals(grocery.Code));
    }
}