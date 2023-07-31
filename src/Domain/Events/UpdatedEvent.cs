namespace CleanArchitecture.Domain.Events;

public class UpdatedEvent<T> : IBaseEvent
{
    public UpdatedEvent(T item)
    {
        Item = item;
    }

    public T Item { get; }
}
