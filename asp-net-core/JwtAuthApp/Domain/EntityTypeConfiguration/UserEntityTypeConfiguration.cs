using JwtAuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthApp.Domain.EntityTypeConfiguration;

public class UserEntityTypeConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        
        builder.HasMany(p => p.Roles)
            .WithMany()
            .UsingEntity(
                "users_roles",
                l => l.HasOne(typeof(Role)).WithMany().HasForeignKey("role_id"),
                r => r.HasOne(typeof(User)).WithMany().HasForeignKey("user_id")
            );
    }
    
}