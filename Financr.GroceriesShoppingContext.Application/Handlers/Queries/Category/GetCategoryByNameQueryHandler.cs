using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;

public sealed class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, Result<GetCategoryByNameQueryResponse, CommandErrorValidation>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryByNameQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetCategoryByNameQueryResponse, CommandErrorValidation>> Handle(GetCategoryByNameQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (query.Errors.Count > 0)
            return new Result<GetCategoryByNameQueryResponse, CommandErrorValidation>(query.Errors);

        var category = await _repository.GetCategoryByName(query.Name, cancellationToken);
        
        if(category is null)
            return new Result<GetCategoryByNameQueryResponse, CommandErrorValidation>(new List<CommandErrorValidation>
            {
                new(nameof(query.Name), "Categoria não encontrada")
            });

        var response = new GetCategoryByNameQueryResponse(category);

        return new Result<GetCategoryByNameQueryResponse, CommandErrorValidation>(response);
    }
};