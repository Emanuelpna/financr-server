namespace Financr.GroceriesShoppingContext.Domain.Validators;

public record DomainErrorValidation(string Field, string Message) : IErrorValidation;
