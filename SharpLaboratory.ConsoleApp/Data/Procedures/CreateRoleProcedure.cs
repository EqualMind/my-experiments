using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Procedures;

public class CreateRoleProcedure : IStorageProcedure
{
    private readonly string _name;
    
    public CreateRoleProcedure(string name)
    {
        _name = name;
    }
    
    public async Task ApplyAsync(IStorageProcedureContext context) 
        => await context.AddAndSaveAsync<Role, Guid>(new Role { Name = _name });
}