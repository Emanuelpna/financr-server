using Financr.GroceriesShoppingContext.Domain.Entities;

namespace Financr.GroceriesShoppingContext.Domain.Tests;

public class CategoryTests
{
    [Fact]
    public void Test_ShouldCreateCategoryWithName()
    {
        const string categoryName = "Category Name";
        
        var sut = new Category(categoryName);
        
        Assert.Equal(categoryName, sut.Name);
    }
}