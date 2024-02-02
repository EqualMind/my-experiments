using Microsoft.EntityFrameworkCore;
using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Queries;

public class GetRoleByNameQuery : IStorageQuery<Role, Guid, Role>
{
    private readonly string _roleName;

    public GetRoleByNameQuery(string roleName)
    {
        _roleName = roleName;
    }

    public Task<Role> ApplyAsync(IQueryable<Role> entities)
        => entities.SingleAsync(e => e.Name == _roleName);
}