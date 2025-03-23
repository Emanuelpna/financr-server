using Financr.GroceriesShoppingContext.Domain.Commands;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Domain.Abstractions;

public record Result<T, TE> where T : ICommandResponse where TE : IErrorValidation
{
    public T? Data { get; }
    public IList<TE>? Errors { get; } = null;

    public Result(T? data)
    {
        Data = data;
    }
    
    public Result(IList<TE>? errors)
    {
       Errors = errors;
    }

    public bool IsSuccess => Errors == null;
}
