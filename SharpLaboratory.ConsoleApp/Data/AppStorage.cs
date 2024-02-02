using Microsoft.EntityFrameworkCore;
using SharpLaboratory.DataManagement;

namespace SharpLaboratory.ConsoleApp.Data;

public sealed class AppStorage : DataStorage, IApplicationStorage
{
    private readonly bool _isConfiguredByOptions;
    
    public AppStorage()
    {
        _isConfiguredByOptions = false;
    }
    
    public AppStorage(DbContextOptions<AppStorage> options) : base(options)
    {
        _isConfiguredByOptions = true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_isConfiguredByOptions)
        {
            base.OnConfiguring(optionsBuilder);
            return;
        }
        
        optionsBuilder.UseSqlite($"Data Source=Example.sqlite");
        optionsBuilder.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning));
    }
}