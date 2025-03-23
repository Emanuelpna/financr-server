using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Queries.Purchase;

public sealed record GetPurchaseByIdQuery(Guid PurchaseId) : ICommand<GetPurchaseByIdQueryResponse>, IValidator<CommandErrorValidation>
{
    public List<CommandErrorValidation> Errors { get; } = [];
    
    public void Validate()
    {
        if(PurchaseId == Guid.Empty)
            Errors.Add(new CommandErrorValidation(nameof(PurchaseId), "Id da Compra é obrigatório"));        
    }

}