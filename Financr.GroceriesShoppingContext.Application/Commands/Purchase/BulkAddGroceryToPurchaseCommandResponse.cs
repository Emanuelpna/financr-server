using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record BulkAddGroceryToPurchaseCommandResponse(
    Guid PurchaseId,
    int GroceriesAdded
) : ICommandResponse;