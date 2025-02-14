using Financr.GroceriesShoppingContext.Application.Queries.Grocery;

namespace Financr.GroceriesShoppingContext.Application.Tests.Queries.Grocery;

public class GetGroceryByNameQueryTests
{
    [Fact]
    public void Test_ShouldGenerateGetGroceryByNameCommand()
    {
        const string groceryName = "Grocery Name";
        
        var command = new GetGroceryByNameQuery(groceryName);
        command.Validate();    
        
        Assert.Empty(command.Errors);
        
        Assert.Equal(groceryName, command.Name);
    }
    
    [Fact]
    public void Test_ShouldNotGenerateGetGroceryByNameCommandWithEmptyCode()
    {
        const string groceryName = "";
        
        var command = new GetGroceryByNameQuery(groceryName);
        command.Validate();    
        
        Assert.NotEmpty(command.Errors);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Name"));
    }
}

