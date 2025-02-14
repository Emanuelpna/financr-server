using Financr.GroceriesShoppingContext.Application.Queries.Category;

namespace Financr.GroceriesShoppingContext.Application.Tests.Queries.Category;

public class GetCategoryByNameQueryTests
{
    [Fact]
    public void Test_ShouldGenerateGetCategoryByNameCommand()
    {
        const string categoryName = "Category Name";
        
        var command = new GetCategoryByNameQuery(categoryName);
        command.Validate();    
        
        Assert.Empty(command.Errors);
        
        Assert.Equal(categoryName, command.Name);
    }
    
    [Fact]
    public void Test_ShouldNotGenerateGetCategoryByNameCommandWithInvalidCommandData()
    {
        var command = new GetCategoryByNameQuery(string.Empty);
        command.Validate();    
        
        Assert.NotEmpty(command.Errors);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Name"));
    }
}