using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Commands.Category;

public sealed record CreateCategoryCommandResponse(
    Guid Id,
    string Name
) : ICommandResponse;