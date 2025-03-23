using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByNameQuery(string Name) : ICommand<Result<GetGroceryByNameQueryResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(string.IsNullOrEmpty(Name))
            Errors.Add(new CommandErrorValidation(nameof(Name), "Nome do Produto é obrigatório"));
    }

}