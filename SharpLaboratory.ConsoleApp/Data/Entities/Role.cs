using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharpLaboratory.DataManagement;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Entities;

public sealed class Role : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

public class RoleConfiguration : EntityConfiguration<Role, Guid>
{
    protected override void ConfigureEntityCustomFields(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasIndex(e => e.Name)
            .IsUnique();
    }
}