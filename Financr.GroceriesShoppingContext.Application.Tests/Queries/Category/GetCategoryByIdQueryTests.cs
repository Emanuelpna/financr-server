using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Queries.Category;

public class GetCategoryByIdQueryTests
{
    [Fact]
    public void Test_ShouldGenerateGetCategoryByIdCommand()
    {
        var categoryId = Guid.NewGuid();
        
        var command = new GetCategoryByIdQuery(categoryId);
        command.Validate();    
        
        Assert.Empty(command.Errors);
        
        Assert.Equal(categoryId, command.CategoryId);
    }
    
    [Fact]
    public void Test_ShouldNotGenerateGetCategoryByIdCommandWithInvalidCommandData()
    {
        var command = new GetCategoryByIdQuery(Guid.Empty);
        command.Validate();    
        
        Assert.NotEmpty(command.Errors);
        
        Assert.Contains(command.Errors, x => x.Field.Equals("CategoryId"));
    }
}