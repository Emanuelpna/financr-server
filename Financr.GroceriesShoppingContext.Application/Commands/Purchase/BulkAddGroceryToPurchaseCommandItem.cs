using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record BulkAddGroceryToPurchaseCommandItem(
    string Code,
    string Name,
    decimal Amount,
    EGroceryUnitType UnitType,
    decimal Quantity
);