using Microsoft.EntityFrameworkCore;
using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Queries;

public class GetRoleByIdQuery : IStorageQuery<Role, Guid, Role>
{
    private readonly Guid _id;
    
    public GetRoleByIdQuery(Guid id)
    {
        _id = id;
    }

    public Task<Role> ApplyAsync(IQueryable<Role> entities)
        => entities.SingleAsync(e => e.Id == _id);
}