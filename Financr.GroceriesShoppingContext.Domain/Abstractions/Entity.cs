namespace Financr.GroceriesShoppingContext.Domain.Abstractions;

public abstract class Entity : IEquatable<Guid>
{
    public Guid Id { get; protected init; } = Guid.NewGuid();
    
    public bool Equals(Guid other) => Id == other;

    public override int GetHashCode() => Id.GetHashCode();

}