using Financr.GroceriesShoppingContext.Application.Queries.Grocery;

namespace Financr.GroceriesShoppingContext.Application.Tests.Queries.Grocery;

public class ListGroceriesQueryTests
{
    [Fact]
    public void Test_ShouldGenerateListGroceriesCommand()
    {
        var command = new ListGroceriesQuery();
        command.Validate();    
        
        Assert.Empty(command.Errors);
    }
}

