using Financr.GroceriesShoppingContext.Application.Queries.Category;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Category;

public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdQueryResponse, CommandErrorValidation>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryByIdQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetCategoryByIdQueryResponse, CommandErrorValidation>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (query.Errors.Count > 0)
            return new Result<GetCategoryByIdQueryResponse, CommandErrorValidation>(query.Errors);

        var category = await _repository.GetCategoryById(query.CategoryId, cancellationToken);
        
        if(category is null)
            return new Result<GetCategoryByIdQueryResponse, CommandErrorValidation>(new List<CommandErrorValidation>
            {
                new(nameof(query.CategoryId), "Categoria não encontrada")
            });

        var response = new GetCategoryByIdQueryResponse(category);

        return new Result<GetCategoryByIdQueryResponse, CommandErrorValidation>(response);
    }
};