using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record ListGroceriesQuery() : ICommand<ListGroceriesQueryResponse>, IValidator<DomainErrorValidation>
{
    public List<DomainErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
    }

}