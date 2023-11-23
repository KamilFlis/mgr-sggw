using JwtAuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAuthApp.Domain.EntityTypeConfiguration;

public class DataEntityTypeConfiguration: IEntityTypeConfiguration<Data>
{
    public void Configure(EntityTypeBuilder<Data> builder)
    {
        builder.ToTable("data");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Surname).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
        builder.Property(p => p.IntegerNumber).IsRequired();
        builder.Property(p => p.DecimalNumber).IsRequired();
        builder.HasMany(p => p.Addresses)
            .WithMany()
            .UsingEntity(
                "data_addresses",
                l => l.HasOne(typeof(Address)).WithMany().HasForeignKey("address_id"),
                r => r.HasOne(typeof(Data)).WithMany().HasForeignKey("data_id")
            );
        builder.HasMany(p => p.Members).WithOne();

    }
}