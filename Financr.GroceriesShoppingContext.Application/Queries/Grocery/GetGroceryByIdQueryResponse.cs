using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByIdQueryResponse(Domain.Aggregates.GroceryAggregate.Grocery Grocery) :ICommandResponse;