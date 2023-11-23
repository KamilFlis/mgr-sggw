using JwtAuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthApp.Domain.EntityTypeConfiguration;

public class RoleEntityTypeConfiguration: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();

        builder.HasMany(p => p.Privileges)
            .WithMany()
            .UsingEntity(
                "roles_privileges",
                l => l.HasOne(typeof(Privilege)).WithMany().HasForeignKey("privilege_id"),
                r => r.HasOne(typeof(Role)).WithMany().HasForeignKey("role_id")
            );
    }
}