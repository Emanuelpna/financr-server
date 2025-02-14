using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Category;

public sealed record GetCategoryByIdQueryResponse(Domain.Entities.Category Category) : ICommandResponse;