using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record ListGroceriesQueryResponse(IEnumerable<Domain.Entities.Grocery> Groceries) : ICommandResponse;