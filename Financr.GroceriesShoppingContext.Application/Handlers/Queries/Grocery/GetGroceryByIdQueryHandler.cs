using Financr.GroceriesShoppingContext.Application.Queries.Grocery;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Grocery;

public sealed class GetGroceryByIdQueryHandler : IRequestHandler<GetGroceryByIdQuery, Result<GetGroceryByIdQueryResponse, CommandErrorValidation>>
{
    private readonly IGroceryRepository _repository;

    public GetGroceryByIdQueryHandler(IGroceryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetGroceryByIdQueryResponse, CommandErrorValidation>> Handle(GetGroceryByIdQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (query.Errors.Count > 0)
            return new Result<GetGroceryByIdQueryResponse, CommandErrorValidation>(query.Errors);

        var grocery = await _repository.GetGroceryById(query.GroceryId, cancellationToken);

        if (grocery is null)
            return new Result<GetGroceryByIdQueryResponse, CommandErrorValidation>(
                new List<CommandErrorValidation>
                {
                    new (nameof(query.GroceryId), "Produto não encontrado")
                });

        var response = new GetGroceryByIdQueryResponse(grocery);

        return new Result<GetGroceryByIdQueryResponse, CommandErrorValidation>(response);
    }
    
}