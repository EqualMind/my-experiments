using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Tests.Infrastructure;

public abstract class TestBase : IDisposable
{
    private SqliteTesitingContext TestContext { get; } = new();

    protected IDataStorage DataStorage => TestContext.DataStorage;

    public void Dispose()
    {
        TestContext.Dispose();
    }
}