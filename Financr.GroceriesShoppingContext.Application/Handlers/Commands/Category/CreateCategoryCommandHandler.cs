using Financr.GroceriesShoppingContext.Application.Commands.Category;
using Financr.GroceriesShoppingContext.Domain.Handlers;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Responses;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Commands.Category;

public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<CreateCategoryCommandResponse, CommandErrorValidation>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (command.Errors.Count > 0)
            return new Result<CreateCategoryCommandResponse, CommandErrorValidation>(null, command.Errors);

        var category = new Domain.Entities.Category(command.Name);
        
        await _repository.CreateCategory(category);

        var response = new CreateCategoryCommandResponse(category.Id, category.Name);
        
        return new Result<CreateCategoryCommandResponse, CommandErrorValidation>(response); 
    }
}