namespace SharpLaboratory.DataManagement.Contracts;

/// <summary>Общий интерфейс для запросов в хранилище данных приложения</summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип ключа сущности</typeparam>
/// <typeparam name="TResult">Тип возвращаемого запросом результата</typeparam>
public interface IStorageQuery<in TEntity, TKey, TResult> where TEntity : class, IEntity<TKey>
{
    /// <summary>Тело запроса в хранилище данных</summary>
    /// <param name="entities"></param>
    Task<TResult> ApplyAsync(IQueryable<TEntity> entities);
}