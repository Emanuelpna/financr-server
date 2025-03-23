using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Category;

public sealed record ListCategoriesQuery : ICommand<Result<ListCategoriesQueryResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
    }
}