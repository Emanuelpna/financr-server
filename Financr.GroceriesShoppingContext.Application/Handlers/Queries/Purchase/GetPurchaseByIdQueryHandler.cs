using Financr.GroceriesShoppingContext.Application.Queries.Purchase;
using Financr.GroceriesShoppingContext.Domain.Repositories;
using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Application.Handlers.Queries.Purchase;

public sealed class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, Result<GetPurchaseByIdQueryResponse, CommandErrorValidation>>
{
    private readonly IPurchaseRepository _repository;

    public GetPurchaseByIdQueryHandler(IPurchaseRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<GetPurchaseByIdQueryResponse, CommandErrorValidation>> Handle(GetPurchaseByIdQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (query.Errors.Count > 0)
            return new Result<GetPurchaseByIdQueryResponse, CommandErrorValidation>(query.Errors);

        var purchase = await _repository.GetPurchaseById(query.PurchaseId, cancellationToken);

        if (purchase is null)
            return new Result<GetPurchaseByIdQueryResponse, CommandErrorValidation>(
                new List<CommandErrorValidation>
                {
                    new(nameof(query.PurchaseId), "Compra não encontrada")
                });

        var response = new GetPurchaseByIdQueryResponse(purchase);

        return new Result<GetPurchaseByIdQueryResponse, CommandErrorValidation>(response);
    }
}