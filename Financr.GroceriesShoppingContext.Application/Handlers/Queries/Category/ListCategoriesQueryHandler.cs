using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;

public sealed class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, Result<ListCategoriesQueryResponse, CommandErrorValidation>>
{
    private readonly ICategoryRepository _repository;

    public ListCategoriesQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<ListCategoriesQueryResponse, CommandErrorValidation>> Handle(ListCategoriesQuery command, CancellationToken cancellationToken)
    {
        var categories = await _repository.ListCategories(cancellationToken);

        var response = new ListCategoriesQueryResponse(categories);
        
        return new Result<ListCategoriesQueryResponse, CommandErrorValidation>(response);
    }
};