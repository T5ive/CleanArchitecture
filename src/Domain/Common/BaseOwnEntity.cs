namespace CleanArchitecture.Domain.Common;

public abstract class BaseOwnEntity<T> : BaseEntity<T>, IBaseOwnEntity
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }
}
