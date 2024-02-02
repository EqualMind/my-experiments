using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharpLaboratory.DataManagement;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.ConsoleApp.Data.Entities;

public class UserRole : IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public User User { get; set; }

    public Role Role { get; set; }
}

public class UserRoleConfiguration : EntityConfiguration<UserRole, Guid>
{
    protected override void ConfigureEntityCustomFields(EntityTypeBuilder<UserRole> builder)
    {
        builder
            .HasOne(e => e.Role)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.RoleId);

        builder
            .HasOne(e => e.User)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.UserId);

        builder
            .HasIndex(e => new { e.UserId, e.RoleId })
            .IsUnique();
    }
}