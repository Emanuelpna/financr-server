using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Enums;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Commands.Grocery;

public sealed record CreateGroceryCommand(
    string Code,
    string Name,
    decimal Amount,
    EGroceryUnitType UnitType,
    decimal Quantity
) :  ICommand<Result<CreateGroceryCommandResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(Code))
            Errors.Add(new CommandErrorValidation(nameof(Code), "Código do Produto é obrigatório"));
        
        if (string.IsNullOrEmpty(Name))
            Errors.Add(new CommandErrorValidation(nameof(Name), "Nome do Produto é obrigatório"));
        
        if (Amount <= 0)
            Errors.Add(new CommandErrorValidation(nameof(Amount), "Preço do Produto deve ser maior que zero"));
        
        if (!Enum.IsDefined(typeof(EGroceryUnitType), UnitType))
            Errors.Add(new CommandErrorValidation(nameof(UnitType), "Tipo de Produto inválido"));
        
        if (Quantity <= 0)
            Errors.Add(new CommandErrorValidation(nameof(Quantity), "Quantidade do Produto deve ser maior que zero"));
    }
}