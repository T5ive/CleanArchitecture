namespace CleanArchitecture.Domain.Share.Common;

public interface IAuditableEntity : IBaseOwnEntity
{
    string? LastModifiedBy { get; set; }

    DateTime? LastModified { get; set; }
}
