namespace Financr.GroceriesShoppingContext.Domain.Validators;

public record DomainErrorValidation(string ModelName, string Message) : ErrorValidation(ModelName, Message);
