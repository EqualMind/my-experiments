using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.DataManagement;

/// <summary>Базовый класс для реализации хранилища данных</summary>
public abstract class DataStorage : DbContext, IDataStorage, IStorageProcedureContext
{
    protected DataStorage() : base(new DbContextOptions<DataStorage>())
    {
        
    }
    
    protected DataStorage(DbContextOptions options) : base(options)
    {
        
    }

    public async Task<TResult> ReadAsync<TEntity, TKey, TResult>([NotNull] IStorageQuery<TEntity, TKey, TResult> query) where TEntity : class, IEntity<TKey>
        => await query.ApplyAsync(Set<TEntity>().AsNoTrackingWithIdentityResolution());

    public async Task ExecuteProcedureAsync(IStorageProcedure procedure)
        => await procedure.ApplyAsync(this);

    public async Task AddAndSaveAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntity<TKey>
    {
        ClearTracking();
        Add(entity);
        await SaveChangesAsync();
        ClearTracking();
    }

    public async Task AddRangeAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>
    {
        ClearTracking();
        AddRange(entities);
        await SaveChangesAsync();
        ClearTracking();
    }

    public async Task UpdateAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entity) where TEntity : class, IEntity<TKey>
    {
        ClearTracking();
        Update(entity);
        await SaveChangesAsync();
        ClearTracking();
    }

    public async Task UpdateRangeAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>
    {
        ClearTracking();
        UpdateRange(entities);
        await SaveChangesAsync();
        ClearTracking();
    }

    public async Task DeleteAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entity) where TEntity : class, IEntity<TKey>
    {
        ClearTracking();
        Remove(entity);
        await SaveChangesAsync();
        ClearTracking();
    }

    public async Task DeleteRangeAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>
    {
        ClearTracking();
        RemoveRange(entities);
        await SaveChangesAsync();
        ClearTracking();
    }

    private void ClearTracking() => ChangeTracker.Clear();
}