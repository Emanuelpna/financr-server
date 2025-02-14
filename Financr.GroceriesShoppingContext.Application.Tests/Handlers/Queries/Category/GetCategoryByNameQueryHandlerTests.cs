using Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Application.Tests.Mocks;

namespace Financr.GroceriesShoppingContext.Application.Tests.Handlers.Queries.Category;

public class GetCategoryByNameQueryHandlerTests
{
    [Fact]
    public async Task Test_ShouldGetCategoryByName()
    {
        var repository = new MockCategoryRepository();
            
        var queryHandler = new GetCategoryByNameQueryHandler(repository);
        
        var query = new GetCategoryByNameQuery(repository.ExistingCategoryName);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingCategoryId, result.Data.Category.Id);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetCategoryByNameWithInvalidQueryData()
    {
        var repository = new MockCategoryRepository();
            
        var queryHandler = new GetCategoryByNameQueryHandler(repository);
        
        var query = new GetCategoryByNameQuery(string.Empty);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("Name"));
    }
}