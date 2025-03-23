using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;

public sealed class BulkAddGroceryToPurchaseCommandHandler : IRequestHandler<BulkAddGroceryToPurchaseCommand, Result<BulkAddGroceryToPurchaseCommandResponse, CommandErrorValidation>>
{
    private readonly IPurchaseRepository _repository;

    public BulkAddGroceryToPurchaseCommandHandler(IPurchaseRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<BulkAddGroceryToPurchaseCommandResponse, CommandErrorValidation>> Handle(BulkAddGroceryToPurchaseCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (command.Errors.Count > 0)
            return new Result<BulkAddGroceryToPurchaseCommandResponse, CommandErrorValidation>(command.Errors);

        var purchase = await _repository.GetPurchaseById(command.PurchaseId, cancellationToken);
        
        if(purchase is null)
            return new Result<BulkAddGroceryToPurchaseCommandResponse, CommandErrorValidation>(new List<CommandErrorValidation>
            {
                new(nameof(command.PurchaseId), "Compra não encontrada")
            });

        var groceries =  command.Groceries
            .Select(grocery =>
                new Domain.Entities.Grocery(
                    grocery.Code, 
                    grocery.Name, 
                    grocery.Amount, 
                    grocery.Quantity,
                    grocery.UnitType
                )
            )
            .ToList();
        
        var groceriesAdded = purchase.SetGroceries(groceries);
        
        if(purchase.Errors.Count > 0)
            return new Result<BulkAddGroceryToPurchaseCommandResponse, CommandErrorValidation>(new List<CommandErrorValidation>
            {
                new(nameof(command.Groceries), "Não é possível adicionar produtos repetidos a uma Compra")
            });

        await _repository.BulkAddGrocery(purchase.Id, groceries, cancellationToken);

        var response = new BulkAddGroceryToPurchaseCommandResponse(purchase.Id, groceriesAdded);
        
        return new Result<BulkAddGroceryToPurchaseCommandResponse, CommandErrorValidation>(response);
    }
}