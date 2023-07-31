namespace CleanArchitecture.Application.Share.Common.Models;

public abstract class EntityDto<T>
{
    public T? Id { get; set; }
}
