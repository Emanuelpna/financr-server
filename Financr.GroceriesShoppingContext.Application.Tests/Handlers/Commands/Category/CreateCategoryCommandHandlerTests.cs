using Financr.GroceriesShoppingContext.Application.Commands.Category;
using Financr.GroceriesShoppingContext.Application.Handlers.Commands.Category;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Commands.Category;

public class CreateCategoryCommandHandlerTests
{
    [Fact]
    public async Task Test_ShouldCreateCategory()
    {
        var repository = new MockCategoryRepository();
            
        var commandHandler = new CreateCategoryCommandHandler(repository);

        const string categoryName = "Category Name";
        
        var command = new CreateCategoryCommand(categoryName);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(categoryName, result.Data.Name);
    }
    
    [Fact]
    public async Task Test_ShouldNotCreateCategoryWithInvalidCommandData()
    {
        var repository = new MockCategoryRepository();
            
        var commandHandler = new CreateCategoryCommandHandler(repository);
        
        var command = new CreateCategoryCommand("");
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Name"));
    }
}