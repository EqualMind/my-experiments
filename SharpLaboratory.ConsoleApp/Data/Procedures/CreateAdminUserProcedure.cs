using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.ConsoleApp.Data.Queries;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Procedures;

public class CreateAdminUserProcedure : IStorageProcedure
{
    private readonly User _userTemplate;

    public CreateAdminUserProcedure(User userTemplate)
    {
        _userTemplate = userTemplate;
    }

    public async Task ApplyAsync(IStorageProcedureContext context)
    {
        await context.AddAndSaveAsync<User, Guid>(new User
        {
            Email = _userTemplate.Email,
            Password = _userTemplate.Password
        });

        var userInfo = await context.ReadAsync(new GetUserByEmailAndPasswordQuery(_userTemplate.Email, _userTemplate.Password));
        var roleInfo = await context.ReadAsync(new GetRoleByNameQuery("Admin"));
        await context.ExecuteProcedureAsync(new AddRoleToUserProcedure(userInfo.Id, roleInfo.Id));
    }
}