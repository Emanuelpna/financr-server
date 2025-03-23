using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Category;

public sealed record GetCategoryByIdQuery(Guid CategoryId) : ICommand<Result<GetCategoryByIdQueryResponse, CommandErrorValidation>>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(CategoryId == Guid.Empty)
            Errors.Add(new CommandErrorValidation(nameof(CategoryId), "ID da Categoria é obrigatória"));
    }
}