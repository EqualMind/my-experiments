using Microsoft.EntityFrameworkCore;
using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Queries;

public class GetUserInfo : IStorageQuery<User, Guid, User>
{
    private readonly Guid _userId;

    public GetUserInfo(Guid userId)
    {
        _userId = userId;
    }

    public Task<User> ApplyAsync(IQueryable<User> entities)
        => entities
            .Include(e => e.UserRoles)
                .ThenInclude(e => e.Role)
            .AsSplitQuery()
            .SingleAsync(e => e.Id == _userId);
}