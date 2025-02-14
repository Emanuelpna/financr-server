using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByIdQuery(Guid GroceryId) : ICommand<GetGroceryByIdQueryResponse>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(GroceryId == Guid.Empty) 
            Errors.Add(new CommandErrorValidation(nameof(GroceryId), "ID do Produto é obrigatório"));
    }

}