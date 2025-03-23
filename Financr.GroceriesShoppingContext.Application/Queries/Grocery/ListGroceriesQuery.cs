using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Grocery;

public sealed record ListGroceriesQuery : ICommand<Result<ListGroceriesQueryResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
    }

}