namespace Financr.GroceriesShoppingContext.Domain.Entities;

public class Category : Entity
{
    public Category(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}