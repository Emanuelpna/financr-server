using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Category;

public sealed record ListCategoriesQueryResponse(IEnumerable<Domain.Entities.Category> Categories) : ICommandResponse;