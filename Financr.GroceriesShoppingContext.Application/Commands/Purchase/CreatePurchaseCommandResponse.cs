using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record CreatePurchaseCommandResponse(Guid PurchaseId) : ICommandResponse;