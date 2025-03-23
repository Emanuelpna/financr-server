using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.ValueObjects;

namespace Financr.GroceriesShoppingContext.Domain.Entities;

public class GroceryPrice : Entity
{
    public GroceryPrice(decimal amount, GroceryQuantity quantity, Guid groceryId)
    {
        Amount = amount;
        Quantity = quantity;
        GroceryId = groceryId;
    }

    public GroceryPrice(decimal amount, GroceryQuantity quantity, Guid groceryId, Grocery grocery)
    {
        Amount = amount;
        Quantity = quantity;
        GroceryId = groceryId;
        Grocery = grocery;
    }

    public decimal Amount { get; private set; }

    public GroceryQuantity Quantity { get; private set; }

    public Guid GroceryId { get; private set; }
    
    public Grocery Grocery { get; private set; }

    public decimal GetPricePerUnit()
    {
        return Quantity.GetAmountByQuantityPerWholeUnit(Amount);
    }
}