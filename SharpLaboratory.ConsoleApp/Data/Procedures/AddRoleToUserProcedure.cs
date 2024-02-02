using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Procedures;

public class AddRoleToUserProcedure : IStorageProcedure
{
    private readonly Guid _userId;
    private readonly Guid _roleId;

    public AddRoleToUserProcedure(Guid userId, Guid roleId)
    {
        _userId = userId;
        _roleId = roleId;
    }

    public Task ApplyAsync(IStorageProcedureContext context)
        => context.AddAndSaveAsync<UserRole, Guid>(new UserRole
        {
            UserId = _userId,
            RoleId = _roleId
        });
}