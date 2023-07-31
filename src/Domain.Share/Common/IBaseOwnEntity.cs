namespace CleanArchitecture.Domain.Share.Common;

public interface IBaseOwnEntity : IBaseEntity
{
    DateTime Created { get; set; }

    string? CreatedBy { get; set; }
}
