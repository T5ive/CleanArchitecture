namespace CleanArchitecture.Domain.Share.Common;

public interface IFullBaseAuditableEntity : IAuditableEntity
{
    bool IsDeleted { get; set; }
    string? DeletedBy { get; set; }
    DateTime? Deleted { get; set; }
}
