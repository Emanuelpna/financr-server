using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByIdQuery(Guid GroceryId) : ICommand<Result<GetGroceryByIdQueryResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(GroceryId == Guid.Empty) 
            Errors.Add(new CommandErrorValidation(nameof(GroceryId), "ID do Produto é obrigatório"));
    }

}