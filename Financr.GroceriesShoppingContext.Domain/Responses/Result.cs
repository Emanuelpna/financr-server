using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Domain.Responses;

public record Result<T, TE>(T? Data, IList<TE>? Errors = null) where T : ICommandResponse where TE : IErrorValidation
{
    public bool IsSuccess => Errors == null;
}
