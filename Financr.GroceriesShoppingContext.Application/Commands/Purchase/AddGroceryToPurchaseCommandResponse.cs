using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record AddGroceryToPurchaseCommandResponse(
    Guid PurchaseId,
    Guid GroceryId
) : ICommandResponse;