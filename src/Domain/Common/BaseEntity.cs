namespace CleanArchitecture.Domain.Common;

public abstract class BaseEntity<T> : IBaseEntity
{
    // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    // Using non-generic integer types for simplicity
    public T? Id { get; set; }

    private readonly List<IBaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<IBaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IBaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(IBaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
