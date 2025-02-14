using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Responses;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Domain.Handlers;

public interface ICommandHandler<in TC, TR> where TC : ICommand<TR> where TR : ICommandResponse
{
    Task<Result<TR, CommandErrorValidation>> Handle(TC command, CancellationToken cancellationToken);
}