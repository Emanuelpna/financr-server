namespace Financr.GroceriesShoppingContext.Domain.Validators;

public interface IErrorValidation
{
    public string Field { get; }
    public string Message { get; }
};