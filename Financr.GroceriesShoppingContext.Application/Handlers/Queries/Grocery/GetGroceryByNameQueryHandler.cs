using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Responses;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class GetGroceryByNameQueryHandler : ICommandHandler<GetGroceryByNameQuery, GetGroceryByNameQueryResponse>
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
            return new Result<GetGroceryByNameQueryResponse, CommandErrorValidation>(null, query.Errors);

        var grocery = await _repository.GetGroceryByName(query.Name);

        if (grocery is null)
            return new Result<GetGroceryByNameQueryResponse, CommandErrorValidation>(null,
                new List<CommandErrorValidation>
                {
                    new CommandErrorValidation(nameof(query.Name), "Produto não encontrado")
                });

        var response = new GetGroceryByNameQueryResponse(grocery);

        return new Result<GetGroceryByNameQueryResponse, CommandErrorValidation>(response);
    }
}