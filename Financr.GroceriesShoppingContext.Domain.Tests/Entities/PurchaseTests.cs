using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Domain.Tests;

public class PurchaseTests
{
    [Fact]
    public void Test_ShouldAddNewGrocery()
    {
        const string Supermaket_Name = "Supermarket Name";
        const string NFE_Key = "f61e2395-b9f2-4035-aba0-8369b73d6b9c";
        const decimal Total_Amount = 180.94M;
        
        var Purchase_Date = DateTimeOffset.UtcNow.AddHours(-2);
        
        var sut = new Purchase(Purchase_Date, Supermaket_Name, NFE_Key, Total_Amount);

        var grocery = new Grocery("03981029", "Shampoo", 15.80m, 1M, EGroceryUnitType.Un);
        
        sut.AddGrocery(grocery);

        Assert.Contains(sut.Groceries, x => x.Code.Equals(grocery.Code));
    }
    
    [Fact]
    public void Test_ShouldNNotAddRepeatedGrocery()
    {
        const string Supermaket_Name = "Supermarket Name";
        const string NFE_Key = "f61e2395-b9f2-4035-aba0-8369b73d6b9c";
        const decimal Total_Amount = 180.94M;
        
        var Purchase_Date = DateTimeOffset.UtcNow.AddHours(-2);
        
        var sut = new Purchase(Purchase_Date, Supermaket_Name, NFE_Key, Total_Amount);

        var grocery = new Grocery("03981029", "Shampoo", 15.80m, 1M, EGroceryUnitType.Un);
        
        sut.AddGrocery(grocery);
        
        sut.AddGrocery(grocery);

        Assert.Single(sut.Groceries, x => x.Code.Equals(grocery.Code));
    }
}