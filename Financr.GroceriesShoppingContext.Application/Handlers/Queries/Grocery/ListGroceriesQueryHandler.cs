using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class ListGroceriesQueryHandler : IRequestHandler<ListGroceriesQuery, Result<ListGroceriesQueryResponse, CommandErrorValidation>>
{
    private readonly IGroceryRepository _repository;

    public ListGroceriesQueryHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ListGroceriesQueryResponse, CommandErrorValidation>> Handle(ListGroceriesQuery query, CancellationToken cancellationToken)
    {
        var groceries = await _repository.ListGroceries(cancellationToken);

        var response = new ListGroceriesQueryResponse(groceries);

        return new Result<ListGroceriesQueryResponse, CommandErrorValidation>(response);
    }
}