using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Domain.ValueObjects;

public class GroceryQuantity
{
    public GroceryQuantity(EGroceryUnitType unitType, decimal quantity)
    {
        UnitType = unitType;
        Quantity = quantity;
    }

    public EGroceryUnitType UnitType { get; private set; }
    
    public decimal Quantity { get; private set; }

    /// <summary>
    /// Checks the price based on the Unit type.
    /// So if a purchase has 2 units of a item and the total price is 5, it means the price per unit is 2.5.
    /// </summary>
    /// <param name="amount">Total value of the item in the Purchase</param>
    /// <returns></returns>
    public decimal GetAmountByQuantityPerWholeUnit(decimal amount)
    {
    return amount / Quantity;
    }
}