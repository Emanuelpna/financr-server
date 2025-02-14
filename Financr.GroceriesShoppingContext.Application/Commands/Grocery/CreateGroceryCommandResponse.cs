using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Enums;

namespace Financr.GroceriesShoppingContext.Application.Commands.Grocery;

public sealed record CreateGroceryCommandResponse(
    Guid Id
) : ICommandResponse;