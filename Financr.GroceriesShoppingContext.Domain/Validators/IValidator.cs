namespace Financr.GroceriesShoppingContext.Domain.Validators;

public interface IValidator<T> where T : IErrorValidation
{
    public List<T> Errors { get; set; }
}
