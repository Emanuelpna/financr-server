using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record GetGroceryByNameQuery(string Name) : ICommand<GetGroceryByNameQueryResponse>, IValidator<DomainErrorValidation>
{
    public List<DomainErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(string.IsNullOrEmpty(Name))
            Errors.Add(new DomainErrorValidation(nameof(Name), "Nome do Produto é obrigatório"));
    }

}