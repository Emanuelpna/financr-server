namespace Financr.GroceriesShoppingContext.Domain.Entities;

public class Category : Entity
{
    public Category(string name) : base()
    {
        Name = name;
    }

    public string Name { get; set; }
}