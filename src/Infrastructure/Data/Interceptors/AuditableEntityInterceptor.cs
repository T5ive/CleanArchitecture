using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Share.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CleanArchitecture.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly IUser _user;
    private readonly IDateTime _dateTime;

    public AuditableEntityInterceptor(
        IUser user,
        IDateTime dateTime)
    {
        _user = user;
        _dateTime = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            var entityType = entry.Entity.GetType();

            var auditableType = GetEntityType(entityType);

            if (auditableType is EntityType.None) continue;

            if (entry.Entity is not IBaseOwnEntity baseOwnEntity) continue;

            SetOwnEntityProperties(entry, baseOwnEntity);

            if (entry.Entity is not IAuditableEntity auditableEntity) continue;

            SetAuditableProperties(entry, auditableEntity);

            if (entry.Entity is not IFullBaseAuditableEntity fullBaseAuditableEntity) continue;

            SetFullBaseAuditableProperties(entry, fullBaseAuditableEntity);
        }
    }

    private void SetOwnEntityProperties(EntityEntry entry, IBaseOwnEntity entity)
    {
        if (entry.State == EntityState.Added)
        {
            entity.CreatedBy = _user.Id;
            entity.Created = _dateTime.Now;
        }
    }

    private void SetAuditableProperties(EntityEntry entry, IAuditableEntity entity)
    {
        if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
        {
            entity.LastModifiedBy = _user.Id;
            entity.LastModified = _dateTime.Now;
        }
    }

    private void SetFullBaseAuditableProperties(EntityEntry entry, IFullBaseAuditableEntity entity)
    {
        if (entry.State == EntityState.Deleted)
        {
            entry.State = EntityState.Modified;
            entity.IsDeleted = true;
            entity.DeletedBy = _user.Id;
            entity.Deleted = _dateTime.Now;
        }
    }

    private static EntityType GetEntityType(Type type)
    {
        switch (type.IsGenericType)
        {
            case true when type.GetGenericTypeDefinition() == typeof(BaseOwnEntity<>):
                return EntityType.BaseOwnEntity;

            case true when type.GetGenericTypeDefinition() == typeof(BaseAuditableEntity<>):
                return EntityType.BaseAuditableEntity;

            case true when type.GetGenericTypeDefinition() == typeof(FullBaseAuditableEntity<>):
                return EntityType.FullBaseAuditableEntity;
        }

        var baseType = type.BaseType;
        if (baseType != null && baseType != typeof(object))
        {
            return GetEntityType(baseType);
        }

        return EntityType.None;
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}
