using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharpLaboratory.ConsoleApp.Data;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Tests.Infrastructure;

public sealed class SqliteTesitingContext : IDisposable
{
    private readonly SqliteConnection _dbConnection = new($"Data Source={Guid.NewGuid().ToString()};Mode=Memory;Cache=Shared");
    private readonly AppStorage _storage;
    public IDataStorage DataStorage => _storage;
    
    public SqliteTesitingContext()
    {
        var dbContextBuilder = new DbContextOptionsBuilder<AppStorage>();
        _dbConnection.Open();
        dbContextBuilder.UseSqlite(_dbConnection);

        _storage = new(dbContextBuilder.Options);
        _storage.Database.Migrate();
    }
    
    public void Dispose()
    {
        _storage.Database.EnsureDeleted();
        _storage.Dispose();
        _dbConnection.Dispose();
    }
}