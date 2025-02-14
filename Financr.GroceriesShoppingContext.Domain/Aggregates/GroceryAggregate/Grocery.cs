using Financr.GroceriesShoppingContext.Domain.Entities;
using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.ValueObjects;

namespace Financr.GroceriesShoppingContext.Domain.Aggregates.GroceryAggregate;

public class Grocery : Entity
{
    public Grocery(Guid id, string code, string name, decimal amount,  decimal quantity, EGroceryUnitType unitType)
    {
        Id = id;
            
        var groceryQuantity = new GroceryQuantity(unitType, quantity);
        var groceryPrice = new GroceryPrice(amount, groceryQuantity, Id);
        
        Code = code;
        Name = name;
        GroceryPrice = groceryPrice;
    }

    
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