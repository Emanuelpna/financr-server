using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Commands.Category;

public sealed record CreateCategoryCommand(string Name) : ICommand<Result<CreateCategoryCommandResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(Name))
            Errors.Add(new CommandErrorValidation(nameof(Name), "Nome da Categoria é obrigatório"));
    }
}