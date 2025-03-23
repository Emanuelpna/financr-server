using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class GetGroceryByCodeQueryHandler : ICommandHandler<GetGroceryByCodeQuery, GetGroceryByCodeQueryResponse>
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
            return new Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>(null, query.Errors);

        var grocery = await _repository.GetGroceryByCode(query.Code);

        if (grocery is null)
            return new Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>(null, new List<CommandErrorValidation>
            {
                new(nameof(query.Code), "Produto não encontrado")
            });

        var response = new GetGroceryByCodeQueryResponse(grocery);

        return new Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>(response);
    }
};