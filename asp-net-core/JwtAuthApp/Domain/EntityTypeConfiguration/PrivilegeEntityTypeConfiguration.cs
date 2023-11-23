using JwtAuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthApp.Domain.EntityTypeConfiguration;

public class PrivilegeEntityTypeConfiguration: IEntityTypeConfiguration<Privilege>
{
    public void Configure(EntityTypeBuilder<Privilege> builder)
    {
        builder.ToTable("privileges");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
    }
}