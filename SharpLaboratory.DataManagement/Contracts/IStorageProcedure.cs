namespace SharpLaboratory.DataManagement.Contracts;

/// <summary>Общий интерфейс для "хранимок" хранилища данных</summary>
public interface IStorageProcedure
{
    /// <summary>Тело процедуры хранилища данных</summary>
    /// <param name="context">Контекст выполнения процедуры хранилища данных</param>
    Task ApplyAsync(IStorageProcedureContext context);
}