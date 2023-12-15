using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFilter.Domain.Entities;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasIndex(e => e.PlatformName, "UQ_Platforms").IsUnique();

        builder.HasIndex(e => e.PlatformName, "UQ__Platform__85614BEE4AD4F741").IsUnique();

        builder
            .Property(e => e.PlatformId)
            .HasDefaultValueSql("(newid())")
            .HasColumnName("PlatformID");
        builder.Property(e => e.PlatformName).HasMaxLength(50).IsUnicode(false);
    }
}
