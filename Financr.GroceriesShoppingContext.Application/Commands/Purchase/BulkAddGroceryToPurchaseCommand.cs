using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record BulkAddGroceryToPurchaseCommand(
    Guid PurchaseId,
    IList<BulkAddGroceryToPurchaseCommandItem> Groceries
) : ICommand<BulkAddGroceryToPurchaseCommandResponse>
{
    public List<CommandErrorValidation> Errors { get; set; } = [];
    
    public void Validate()
    {
        if (PurchaseId == Guid.Empty)
            Errors.Add(new CommandErrorValidation(nameof(PurchaseId), "ID da Compra é obrigatória"));
        
        if (!Groceries.Any())
            Errors.Add(new CommandErrorValidation(nameof(Groceries), "Lista de Produtos não pode estar vazia"));

        foreach (var grocery in Groceries)
        {
            if (string.IsNullOrEmpty(grocery.Code))
                Errors.Add(new CommandErrorValidation(nameof(grocery.Code), $"Produto {grocery.Code} - Código do Produto é obrigatório"));
        
            if (string.IsNullOrEmpty(grocery.Name))
                Errors.Add(new CommandErrorValidation(nameof(grocery.Name), $"Produto {grocery.Code} - Nome do Produto é obrigatório"));
        
            if (grocery.Amount <= 0)
                Errors.Add(new CommandErrorValidation(nameof(grocery.Amount), $"Produto {grocery.Code} - Preço do Produto deve ser maior que zero"));
        
            if (!Enum.IsDefined(typeof(EGroceryUnitType), grocery.UnitType))
                Errors.Add(new CommandErrorValidation(nameof(grocery.UnitType), $"Produto {grocery.Code} - Tipo de Produto inválido"));
        
            if (grocery.Quantity <= 0)
                Errors.Add(new CommandErrorValidation(nameof(grocery.Quantity), $"Produto {grocery.Code} - Quantidade do Produto deve ser maior que zero")); 
        }
    }
}