using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByCodeQueryResponse(Domain.Entities.Grocery Grocery) : ICommandResponse;