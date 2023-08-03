using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations;

public class CountyConfigurations : IEntityTypeConfiguration<County>
{
    public void Configure(EntityTypeBuilder<County> builder)
    {
        builder.ToTable("County").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name")
            .HasColumnType("varchar(100)");
        builder.Property(p => p.IsActive).HasColumnName("IsActive");

        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(p => p.DeletedBy).HasColumnName("DeletedBy");
        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt");

        builder.HasOne(p => p.City);
        builder.HasOne(p => p.Country).WithMany().OnDelete(DeleteBehavior.Restrict);
    }
}
