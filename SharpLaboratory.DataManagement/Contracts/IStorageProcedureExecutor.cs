namespace SharpLaboratory.DataManagement.Contracts;

/// <summary>Механизм работы с процедурами хранилища данных</summary>
public interface IStorageProcedureExecutor
{
    /// <summary>Выполняет код хранимой процедуры</summary>
    /// <param name="procedure">Объект хранимой процедуры для выполнения</param>
    Task ExecuteProcedureAsync(IStorageProcedure procedure);
}