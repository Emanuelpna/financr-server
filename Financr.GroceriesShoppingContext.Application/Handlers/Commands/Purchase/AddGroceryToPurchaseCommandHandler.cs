using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;

public sealed class AddGroceryToPurchaseCommandHandler : ICommandHandler<AddGroceryToPurchaseCommand, AddGroceryToPurchaseCommandResponse>
{
    private readonly IPurchaseRepository _repository;

    public AddGroceryToPurchaseCommandHandler(IPurchaseRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<AddGroceryToPurchaseCommandResponse, CommandErrorValidation>> Handle(AddGroceryToPurchaseCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (command.Errors.Count > 0)
            return new Result<AddGroceryToPurchaseCommandResponse, CommandErrorValidation>(null, command.Errors);

        var purchase = await _repository.GetPurchaseById(command.PurchaseId);
        
        if(purchase is null)
            return new Result<AddGroceryToPurchaseCommandResponse, CommandErrorValidation>(null, new List<CommandErrorValidation>
            {
                new(nameof(command.PurchaseId), "Compra não encontrada")
            });

        var grocery = new Domain.Entities.Grocery(command.Code, command.Name, command.Amount,
            command.Quantity, command.UnitType);

        await _repository.AddGrocery(purchase.Id, grocery);

        var response = new AddGroceryToPurchaseCommandResponse(purchase.Id, grocery.Id);

        return new Result<AddGroceryToPurchaseCommandResponse, CommandErrorValidation>(response);
    }
}