using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByNameQueryResponse(Domain.Aggregates.GroceryAggregate.Grocery Grocery) : ICommandResponse;