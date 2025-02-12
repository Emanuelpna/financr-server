namespace Financr.GroceriesShoppingContext.Domain.Validators;

public interface IValidator<T> where T : ErrorValidation
{
    public List<T> Errors { get; set; }
}
