using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Commands.Category;

public sealed record CreateCategoryCommand(string Name) : ICommand
{
    public List<CommandErrorValidation> Errors { get; set; } = [];
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            Errors.Add(new CommandErrorValidation(nameof(Name), "Nome da Categoria é obrigatório"));
    }
}