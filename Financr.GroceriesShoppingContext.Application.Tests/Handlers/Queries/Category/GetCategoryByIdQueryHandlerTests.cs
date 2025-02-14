using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Category;

public class GetCategoryByIdQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldGetCategoryById()
    {
        var repository = new MockCategoryRepository();
            
        var commandHandler = new GetCategoryByIdQueryHandler(repository);
        
        var command = new GetCategoryByIdQuery(repository.ExistingCategoryId);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingCategoryId, result.Data.Category.Id);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetCategoryByIdWithInvalidCommandData()
    {
        var repository = new MockCategoryRepository();
            
        var commandHandler = new GetCategoryByIdQueryHandler(repository);
        
        var command = new GetCategoryByIdQuery(Guid.Empty);
            
        var result = await commandHandler.Handle(command, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("CategoryId"));
    }
}