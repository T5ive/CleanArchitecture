namespace CleanArchitecture.Domain.Events;

public class DeletedEvent<T> : IBaseEvent
{
    public DeletedEvent(T item)
    {
        Item = item;
    }

    public T Item { get; }
}
