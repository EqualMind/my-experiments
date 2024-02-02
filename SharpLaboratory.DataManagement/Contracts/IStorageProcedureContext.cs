namespace SharpLaboratory.DataManagement.Contracts;

/// <summary>Контекст для выполнения "хранимой процедуры" хранилища данных</summary>
public interface IStorageProcedureContext : IStorageReader, IStorageProcedureExecutor
{
    /// <summary>Добавить сущность и произвести сохранение изменений</summary>
    /// <remarks>Возможно обернуть в транзакцию, тогда изменения применятся после применения транзакции</remarks>
    /// <param name="entity">Объект сущности</param>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    Task AddAndSaveAsync<TEntity, TKey>(TEntity entity) where TEntity : class, IEntity<TKey>;
    
    /// <summary>Добавить набор сущностей и произвести сохранение изменений</summary>
    /// <remarks>Возможно обернуть в транзакцию, тогда изменения применятся после применения транзакции</remarks>
    /// <param name="entities">Набор объектов сущностей</param>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    Task AddRangeAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>;
    
    /// <summary>Внести изменения в сущность и произвести сохранение изменений</summary>
    /// <remarks>Возможно обернуть в транзакцию, тогда изменения применятся после применения транзакции</remarks>
    /// <param name="entity">Объект сущности</param>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    Task UpdateAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entity) where TEntity : class, IEntity<TKey>;
    
    /// <summary>Внести изменения в набор сущностей и произвести сохранение изменений</summary>
    /// <remarks>Возможно обернуть в транзакцию, тогда изменения применятся после применения транзакции</remarks>
    /// <param name="entities">Набор объектов сущностей</param>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    Task UpdateRangeAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>;
    
    /// <summary>Удалить сущность и произвести сохранение изменений</summary>
    /// <remarks>Возможно обернуть в транзакцию, тогда изменения применятся после применения транзакции</remarks>
    /// <param name="entity">Объект сущности</param>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    Task DeleteAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entity) where TEntity : class, IEntity<TKey>;
    
    /// <summary>Удалить набор сущностей и произвести сохранение изменений</summary>
    /// <remarks>Возможно обернуть в транзакцию, тогда изменения применятся после применения транзакции</remarks>
    /// <param name="entities">Набор объектов сущностей</param>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    Task DeleteRangeAndSaveAsync<TEntity, TKey>(IEnumerable<TEntity> entities) where TEntity : class, IEntity<TKey>;
}