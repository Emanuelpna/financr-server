using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Commands.Purchase;

public sealed record CreatePurchaseCommand(
    DateTimeOffset PurchaseDate,
    string SupermarketName,
    string NfeAccessKey,
    decimal TotalAmount
): ICommand
{
    public List<CommandErrorValidation> Errors { get; set; } = [];
    
    public void Validate()
    {
        if (PurchaseDate > DateTimeOffset.UtcNow)
            Errors.Add(new CommandErrorValidation(nameof(PurchaseDate), "Data da compra inválida"));
        
        if (string.IsNullOrEmpty(SupermarketName))
            Errors.Add(new CommandErrorValidation(nameof(SupermarketName), "O nome do supermercado é obrigatório"));
        
        if (string.IsNullOrEmpty(NfeAccessKey))
            Errors.Add(new CommandErrorValidation(nameof(NfeAccessKey), "A Nota Fiscal é obrigatória"));
        
        if(TotalAmount <= 0)
            Errors.Add(new CommandErrorValidation(nameof(TotalAmount), "O valor da compra precisa ser maior que zero"));
    }
}