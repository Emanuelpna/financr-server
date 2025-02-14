using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByIdQuery(Guid GroceryId) : ICommand<GetGroceryByIdQueryResponse>, IValidator<DomainErrorValidation>
{
    public List<DomainErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(GroceryId == Guid.Empty) 
            Errors.Add(new DomainErrorValidation(nameof(GroceryId), "ID do Produto é obrigatório"));
    }

}