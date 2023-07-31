namespace CleanArchitecture.Domain.Events;

public class CreatedEvent<T> : IBaseEvent
{
    public CreatedEvent(T item)
    {
        Item = item;
    }

    public T Item { get; }
}
