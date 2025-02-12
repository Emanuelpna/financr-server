using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record BulkAddGroceryToPurchaseCommand(
    Guid PurchaseId,
    IList<Domain.Entities.Grocery> Groceries
) : ICommand
{
    public List<CommandErrorValidation> Errors { get; set; } = [];
    
    public void Validate()
    {
        if (PurchaseId == Guid.Empty)
            Errors.Add(new CommandErrorValidation(nameof(PurchaseId), "ID da Compra é obrigatória"));
        
        if (!Groceries.Any())
            Errors.Add(new CommandErrorValidation(nameof(Groceries), "Lista de Produtos não pode estar vazia"));
    }
}