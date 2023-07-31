namespace CleanArchitecture.Domain.Share.Common;

public interface IBaseEntity
{
    IReadOnlyCollection<IBaseEvent> DomainEvents { get; }

    void AddDomainEvent(IBaseEvent domainEvent);

    void RemoveDomainEvent(IBaseEvent domainEvent);

    void ClearDomainEvents();
}
