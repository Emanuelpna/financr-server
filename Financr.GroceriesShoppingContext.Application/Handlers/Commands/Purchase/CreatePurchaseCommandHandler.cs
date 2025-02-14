using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Responses;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;

public sealed class CreatePurchaseCommandHandler : ICommandHandler<CreatePurchaseCommand, CreatePurchaseCommandResponse>
{
    private readonly IPurchaseRepository _repository;

    public CreatePurchaseCommandHandler(IPurchaseRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<CreatePurchaseCommandResponse, CommandErrorValidation>> Handle(CreatePurchaseCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (command.Errors.Count > 0)
            return new Result<CreatePurchaseCommandResponse, CommandErrorValidation>(null, command.Errors);

        var purchase = new Domain.Entities.Purchase(command.PurchaseDate, command.SupermarketName, command.NfeAccessKey,
            command.TotalAmount);
        
        await _repository.CreatePurchase(purchase);

        var response = new CreatePurchaseCommandResponse(purchase.Id);

        return new Result<CreatePurchaseCommandResponse, CommandErrorValidation>(response);
    }
}