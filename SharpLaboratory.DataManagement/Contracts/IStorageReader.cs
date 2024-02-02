namespace SharpLaboratory.DataManagement.Contracts;

/// <summary>Механизм чтения данных из хранилища данных</summary>
public interface IStorageReader
{
    /// <summary>Осуществляет чтение данных из хранилища данных по указанному запросу</summary>
    /// <param name="query">Объект запроса</param>
    /// <typeparam name="TEntity">Тип сущности, для которой выполняется запрос</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности</typeparam>
    /// <typeparam name="TResult">Тип возвращаемого результата запроса</typeparam>
    Task<TResult> ReadAsync<TEntity, TKey, TResult>(IStorageQuery<TEntity, TKey, TResult> query) 
        where TEntity : class, IEntity<TKey>;
}