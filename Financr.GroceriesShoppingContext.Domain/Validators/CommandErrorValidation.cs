namespace Financr.GroceriesShoppingContext.Domain.Validators;

public record CommandErrorValidation(string Field, string Message) : ErrorValidation(Field, Message);