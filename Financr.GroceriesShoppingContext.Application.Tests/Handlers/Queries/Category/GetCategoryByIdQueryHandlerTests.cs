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
            
        var queryHandler = new GetCategoryByIdQueryHandler(repository);
        
        var query = new GetCategoryByIdQuery(repository.ExistingCategoryId);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.Null(result.Errors);
        
        Assert.NotNull(result.Data);
        
        Assert.Equal(repository.ExistingCategoryId, result.Data.Category.Id);
    }
    
    [Fact]
    public async Task Test_ShouldNotGetCategoryByIdWithInvalidQueryData()
    {
        var repository = new MockCategoryRepository();
            
        var queryHandler = new GetCategoryByIdQueryHandler(repository);
        
        var query = new GetCategoryByIdQuery(Guid.Empty);
            
        var result = await queryHandler.Handle(query, CancellationToken.None);
        
        Assert.NotNull(result.Errors);
        
        Assert.Null(result.Data);
        
        Assert.Contains(result.Errors, x => x.Field.Equals("CategoryId"));
    }
}