using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.ValueObjects;

namespace Financr.GroceriesShoppingContext.Domain.Entities;

public class Grocery : Entity
{
    public Grocery(string code, string name, decimal amount,  decimal quantity, EGroceryUnitType unitType)
    {
        var groceryQuantity = new GroceryQuantity(unitType, quantity);
        var groceryPrice = new GroceryPrice(amount, groceryQuantity, Id);
        
        Code = code;
        Name = name;
        GroceryPrice = groceryPrice;
    }
    
    public string Code { get; private set; }

    public string Name { get; private set; }

    public GroceryPrice GroceryPrice { get; private set; }
}