namespace CleanArchitecture.Infrastructure.Data.Interceptors;

public enum EntityType
{
    None = 0,
    BaseOwnEntity = 1,
    BaseAuditableEntity = 2,
    FullBaseAuditableEntity = 3
}
