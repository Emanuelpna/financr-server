using Financr.GroceriesShoppingContext.Application.Queries.Grocery;

namespace Financr.GroceriesShoppingContext.Application.Tests.Queries.Grocery;

public class GetGroceryByIdQueryTests
{
    [Fact]
    public void Test_ShouldGenerateGetGroceryByIdCommand()
    {
        var groceryId = Guid.NewGuid();
        
        var command = new GetGroceryByIdQuery(groceryId);
        command.Validate();    
        
        Assert.Empty(command.Errors);
        
        Assert.Equal(groceryId, command.GroceryId);
    }
    
    [Fact]
    public void Test_ShouldNotGenerateGetGroceryByIdCommandWithEmptyCode()
    {
        var groceryId = Guid.Empty;
        
        var command = new GetGroceryByIdQuery(groceryId);
        command.Validate();    
        
        Assert.NotEmpty(command.Errors);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("GroceryId"));
    }
}

