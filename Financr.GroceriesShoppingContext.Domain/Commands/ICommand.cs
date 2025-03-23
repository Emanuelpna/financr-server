using Financr.GroceriesShoppingContext.Domain.Abstractions;
using Financr.GroceriesShoppingContext.Domain.Validators;
using MediatR;

namespace Financr.GroceriesShoppingContext.Domain.Commands;

public interface ICommand<T> : IRequest<T>
{
    void Validate();
}