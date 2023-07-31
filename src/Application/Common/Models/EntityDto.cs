namespace CleanArchitecture.Application.Common.Models;

public abstract class EntityDto<T>
{
    public T? Id { get; set; }
}
