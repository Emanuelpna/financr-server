using Financr.GroceriesShoppingContext.Application.Commands.Grocery;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Commands.Grocery;

public sealed class CreateGroceryCommandHandler : IRequestHandler<CreateGroceryCommand, Result<CreateGroceryCommandResponse, CommandErrorValidation>>
{
    private readonly IGroceryRepository _repository;

    public CreateGroceryCommandHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<CreateGroceryCommandResponse, CommandErrorValidation>> Handle(CreateGroceryCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (command.Errors.Count > 0)
            return new Result<CreateGroceryCommandResponse, CommandErrorValidation>(command.Errors);

        var grocery = new Domain.Entities.Grocery(command.Code, command.Name, command.Amount, command.Quantity, command.UnitType);
        
        await _repository.CreateGrocery(grocery, cancellationToken);
        
        var response = new CreateGroceryCommandResponse(grocery.Id);
        
        return new Result<CreateGroceryCommandResponse, CommandErrorValidation>(response); 
    }
}