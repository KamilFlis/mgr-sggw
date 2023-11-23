using JwtAuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthApp.Domain.EntityTypeConfiguration;

public class MemberEntityTypeConfiguration: IEntityTypeConfiguration<Member>
{

    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("members");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Surname).IsRequired();
    }
}