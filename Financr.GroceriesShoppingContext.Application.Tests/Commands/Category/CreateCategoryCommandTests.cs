using Financr.GroceriesShoppingContext.Application.Commands.Category;

namespace Financr.GroceriesShoppingContext.Application.Tests.Commands.Category;

public class CreateCategoryCommandTests
{
    [Fact]
    public void Test_ShouldCreateCategoryCommandInstanceWithName()
    {
        const string categoryName = "Category Name";
        
        var command = new CreateCategoryCommand(categoryName);
        command.Validate();
        
        Assert.Equal(categoryName, command.Name);
    }
    
    [Fact]
    public void Test_ShouldNotCreateCategoryCommandInstanceWithEmptyName()
    {
        const string categoryName = "";
        
        var command = new CreateCategoryCommand(categoryName);
        command.Validate();
        
        Assert.True(command.Errors.Count == 1);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("Name"));
    }
}