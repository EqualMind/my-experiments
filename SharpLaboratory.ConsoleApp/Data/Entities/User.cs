using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharpLaboratory.DataManagement;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Entities;

public sealed class User : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}

public class UserConfiguration : EntityConfiguration<User, Guid>
{
    protected override void ConfigureEntityCustomFields(EntityTypeBuilder<User> builder)
    {
        builder
            .HasIndex(e => e.Email)
            .IsUnique();
    }
}