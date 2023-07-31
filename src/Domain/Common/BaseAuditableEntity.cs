namespace CleanArchitecture.Domain.Common;

public abstract class BaseAuditableEntity<T> : BaseOwnEntity<T>, IAuditableEntity
{
    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
