using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.ConsoleApp.Data.Procedures;
using SharpLaboratory.ConsoleApp.Data.Queries;
using SharpLaboratory.ConsoleApp.Tests.Infrastructure;
using Xunit;

namespace SharpLaboratory.ConsoleApp.Tests;

public class UsersAndRolesTests : TestBase
{
    [Fact]
    public async Task ProcedureExecution_IsNot_ThrowingExceptions()
    {
        Assert.Null(await Record.ExceptionAsync(async () => await DataStorage.ExecuteProcedureAsync(new CreateRoleProcedure("Admin"))));
    }

    [Fact]
    public async Task GetRoleQueries_Are_ReturnsCorrectData()
    {
        var roleName = "Admin";
        await DataStorage.ExecuteProcedureAsync(new CreateRoleProcedure(roleName));
        
        var role = await DataStorage.ReadAsync(new GetRoleByNameQuery(roleName));
        var roleById = await DataStorage.ReadAsync(new GetRoleByIdQuery(role.Id));
        
        Assert.NotNull(role);
        Assert.Equal(roleName, role.Name);
        Assert.Equal(role.Id, roleById.Id);
    }

    [Fact]
    public async Task CreateUserProcedure_CreatesNewUser_Successfully()
    {
        var user = new User
        {
            Email = "example@mail.ru",
            Password = "Passw0rd"
        };

        await DataStorage.ExecuteProcedureAsync(new CreateUserProcedure(user.Email, user.Password));
        
        var createdUser = await DataStorage.ReadAsync(new GetUserByEmailAndPasswordQuery(user.Email, user.Password));
        
        Assert.NotNull(createdUser);
        Assert.Equal(user.Email, createdUser.Email);
        Assert.Equal(user.Password, createdUser.Password);
    }

    [Fact]
    public async Task ComplexProcedure_Executes_Successfully()
    {
        var user = new User
        {
            Email = "example@mail.ru",
            Password = "Passw0rd"
        };

        await DataStorage.ExecuteProcedureAsync(new CreateRoleProcedure("Admin"));
        await DataStorage.ExecuteProcedureAsync(new CreateAdminUserProcedure(user));
        
        var userInfo = await DataStorage.ReadAsync(new GetUserByEmailAndPasswordQuery(user.Email, user.Password));
        
        Assert.NotNull(userInfo);
        Assert.NotEmpty(userInfo.UserRoles);
        Assert.Contains(userInfo.UserRoles, r => r.Role.Name == "Admin");
    }
}