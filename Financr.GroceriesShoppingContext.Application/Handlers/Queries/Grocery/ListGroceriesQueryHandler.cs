using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Responses;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class ListGroceriesQueryHandler : ICommandHandler<ListGroceriesQuery, ListGroceriesQueryResponse>
{
    private readonly IGroceryRepository _repository;

    public ListGroceriesQueryHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListGroceriesQueryResponse, CommandErrorValidation>> Handle(ListGroceriesQuery query, CancellationToken cancellationToken)
    {
        var groceries = await _repository.ListGroceries();

        var response = new ListGroceriesQueryResponse(groceries);

        return new Result<ListGroceriesQueryResponse, CommandErrorValidation>(response);
    }
}