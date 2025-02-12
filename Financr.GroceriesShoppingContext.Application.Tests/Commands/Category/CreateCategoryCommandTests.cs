using Financr.GroceriesShoppingContext.Application.Commands.Category;

namespace Financr.GroceriesShoppingContext.Application.Tests.Commands.Category;

public class CreateCategoryCommandTests
{
    [Fact]
    public void Test_ShouldCreateCategoryCommandInstanceWithName()
    {
        const string categoryName = "Category Name";
        
        var sut = new CreateCategoryCommand(categoryName);
        sut.Validate();
        
        Assert.Equal(categoryName, sut.Name);
    }
    
    [Fact]
    public void Test_ShouldNotCreateCategoryCommandInstanceWithEmptyName()
    {
        const string categoryName = "";
        
        var sut = new CreateCategoryCommand(categoryName);
        sut.Validate();
        
        Assert.True(sut.Errors.Count == 1);
        
        Assert.Equal("Name", sut.Errors[0].Field);
    }
}