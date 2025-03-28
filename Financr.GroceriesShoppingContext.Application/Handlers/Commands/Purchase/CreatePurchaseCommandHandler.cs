using Financr.GroceriesShoppingContext.Application.Commands.Purchase;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Commands.Purchase;

public sealed class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, Result<CreatePurchaseCommandResponse, CommandErrorValidation>>
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
            return new Result<CreatePurchaseCommandResponse, CommandErrorValidation>(command.Errors);

        var purchase = new Domain.Entities.Purchase(command.PurchaseDate, command.SupermarketName, command.NfeAccessKey,
            command.TotalAmount);
        
        await _repository.CreatePurchase(purchase, cancellationToken);

        var response = new CreatePurchaseCommandResponse(purchase.Id);

        return new Result<CreatePurchaseCommandResponse, CommandErrorValidation>(response);
    }
}