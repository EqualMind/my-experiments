using Microsoft.EntityFrameworkCore;
using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Queries;

public class GetUserByEmailAndPasswordQuery : IStorageQuery<User, Guid, User>
{
    private readonly string _email;
    private readonly string _password;

    public GetUserByEmailAndPasswordQuery(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public Task<User> ApplyAsync(IQueryable<User> entities)
        => entities
            .Include(e => e.UserRoles)
                .ThenInclude(e => e.Role)
            .AsSplitQuery()
            .SingleAsync(e => e.Email == _email && e.Password == _password);
}