using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByNameQueryResponse(Domain.Entities.Grocery Grocery) : ICommandResponse;