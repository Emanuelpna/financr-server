using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class GetGroceryByCodeQueryHandler : IRequestHandler<GetGroceryByCodeQuery, Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>>
{
    private readonly IGroceryRepository _repository;

    public GetGroceryByCodeQueryHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>> Handle(GetGroceryByCodeQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (query.Errors.Count > 0)
            return new Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>(query.Errors);

        var grocery = await _repository.GetGroceryByCode(query.Code, cancellationToken);

        if (grocery is null)
            return new Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>(new List<CommandErrorValidation>
            {
                new(nameof(query.Code), "Produto não encontrado")
            });

        var response = new GetGroceryByCodeQueryResponse(grocery);

        return new Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>(response);
    }
};