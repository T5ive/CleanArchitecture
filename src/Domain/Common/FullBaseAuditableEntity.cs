namespace CleanArchitecture.Domain.Common;

public abstract class FullBaseAuditableEntity<T> : BaseAuditableEntity<T>, IFullBaseAuditableEntity
{
    public bool IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? Deleted { get; set; }
}
