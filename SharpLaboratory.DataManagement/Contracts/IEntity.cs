namespace SharpLaboratory.DataManagement.Contracts;

/// <summary>Сущность хранилища данных</summary>
/// <typeparam name="T">Тип ключа сущности</typeparam>
public interface IEntity<T>
{
    /// <summary>Уникальный ключ сущности</summary>
    T Id { get; set; }
    
    /// <summary>Дата создания сущности</summary>
    DateTime CreatedAt { get; }
}