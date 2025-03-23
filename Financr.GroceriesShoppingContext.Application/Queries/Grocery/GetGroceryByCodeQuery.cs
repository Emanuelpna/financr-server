using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByCodeQuery(string Code) : ICommand<Result<GetGroceryByCodeQueryResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
       if(string.IsNullOrEmpty(Code))
           Errors.Add(new CommandErrorValidation(nameof(Code), "Código do Produto é obrigatório"));
    }

}
