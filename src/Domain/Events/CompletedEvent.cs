namespace CleanArchitecture.Domain.Events;

public class CompletedEvent<T> : IBaseEvent
{
    public CompletedEvent(T item)
    {
        Item = item;
    }

    public T Item { get; }
}
