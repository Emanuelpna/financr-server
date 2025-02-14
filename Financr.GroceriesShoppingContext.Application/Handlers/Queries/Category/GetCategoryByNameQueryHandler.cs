using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Responses;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;

public sealed class GetCategoryByNameQueryHandler : ICommandHandler<GetCategoryByNameQuery, GetCategoryByNameQueryResponse>
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
            return new Result<GetCategoryByNameQueryResponse, CommandErrorValidation>(null, query.Errors);

        var category = await _repository.GetCategoryByName(query.Name);
        
        if(category is null)
            return new Result<GetCategoryByNameQueryResponse, CommandErrorValidation>(null, new List<CommandErrorValidation>
            {
                new(nameof(query.Name), "Categoria não encontrada")
            });

        var response = new GetCategoryByNameQueryResponse(category);

        return new Result<GetCategoryByNameQueryResponse, CommandErrorValidation>(response);
    }
};