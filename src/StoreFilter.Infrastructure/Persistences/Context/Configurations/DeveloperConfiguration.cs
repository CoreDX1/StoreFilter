using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFilter.Domain.Entities;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.HasIndex(e => e.DeveloperName, "UQ_DeveloperName").IsUnique();

        builder.Property(e => e.DeveloperId).ValueGeneratedNever().HasColumnName("DeveloperID");
        builder.Property(e => e.DeveloperName).HasMaxLength(100).IsUnicode(false);
    }
}
