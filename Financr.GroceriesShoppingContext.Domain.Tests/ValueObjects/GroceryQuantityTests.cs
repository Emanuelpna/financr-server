using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.ValueObjects;

namespace Financr.GroceriesShoppingContext.Domain.Tests.ValueObjects;

public class GroceryQuantityTests
{
    [Fact]
    public void Test_ShouldReturnPricePerKilogram()
    {
        const decimal quantityBoughtInKg = 0.5M;
        const int pricePaidBasedOnQuantity = 100;
        const int expectedPriceOfOneKg = 200;
        
        var sut = new GroceryQuantity(EGroceryUnitType.Kg, quantityBoughtInKg);

        var result = sut.GetAmountByQuantityPerWholeUnit(pricePaidBasedOnQuantity);
        
        Assert.Equal(expectedPriceOfOneKg, result);
    }
}