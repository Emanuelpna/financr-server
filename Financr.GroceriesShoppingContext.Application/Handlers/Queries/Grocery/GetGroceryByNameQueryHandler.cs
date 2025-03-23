using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class GetGroceryByNameQueryHandler : IRequestHandler<GetGroceryByNameQuery, Result<GetGroceryByNameQueryResponse, CommandErrorValidation>>
{
    private readonly IGroceryRepository _repository;

    public GetGroceryByNameQueryHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetGroceryByNameQueryResponse, CommandErrorValidation>> Handle(GetGroceryByNameQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (query.Errors.Count > 0)
            return new Result<GetGroceryByNameQueryResponse, CommandErrorValidation>(query.Errors);

        var grocery = await _repository.GetGroceryByName(query.Name, cancellationToken);

        if (grocery is null)
            return new Result<GetGroceryByNameQueryResponse, CommandErrorValidation>(
                new List<CommandErrorValidation>
                {
                    new CommandErrorValidation(nameof(query.Name), "Produto não encontrado")
                });

        var response = new GetGroceryByNameQueryResponse(grocery);

        return new Result<GetGroceryByNameQueryResponse, CommandErrorValidation>(response);
    }
}