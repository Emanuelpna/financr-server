using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Domain.Commands;

public interface ICommand
{
    void Validate();
}