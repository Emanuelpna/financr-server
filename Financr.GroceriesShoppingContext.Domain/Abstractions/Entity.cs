namespace Financr.GroceriesShoppingContext.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; protected init; } = Guid.NewGuid();
}