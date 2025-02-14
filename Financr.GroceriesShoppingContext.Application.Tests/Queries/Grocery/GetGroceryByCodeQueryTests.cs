using Financr.GroceriesShoppingContext.Application.Queries.Grocery;

namespace Financr.GroceriesShoppingContext.Application.Tests.Queries.Grocery;

public class GetGroceryByCodeQueryTests
{
    [Fact]
    public void Test_ShouldGenerateGetGroceryByCodeCommand()
    {
        const string groceryCode = "12345";
        
        var command = new GetGroceryByCodeQuery(groceryCode);
        command.Validate();    
        
        Assert.Empty(command.Errors);
        
        Assert.Equal(groceryCode, command.Code);
    }
    
    [Fact]
    public void Test_ShouldNotGenerateGetGroceryByCodeCommandWithEmptyCode()
    {
        const string groceryCode = "";
        
        var command = new GetGroceryByCodeQuery(groceryCode);
        command.Validate();    
        
        Assert.NotEmpty(command.Errors);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Code"));
    }
}

