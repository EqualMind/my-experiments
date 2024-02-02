using SharpLaboratory.ConsoleApp.Data.Entities;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Procedures;

public class CreateUserProcedure : IStorageProcedure
{
    private readonly string Email;
    private readonly string Password;

    public CreateUserProcedure(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public async Task ApplyAsync(IStorageProcedureContext context)
        => await context.AddAndSaveAsync<User, Guid>(new User
        {
            Email = Email,
            Password = Password
        });
}