using Financr.GroceriesShoppingContext.Domain.Commands;

namespace Financr.GroceriesShoppingContext.Application.Queries.Purchase;

public sealed record GetPurchaseByIdQueryResponse(Domain.Entities.Purchase Purchase) : ICommandResponse;