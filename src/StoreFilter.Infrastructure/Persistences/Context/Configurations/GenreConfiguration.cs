using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFilter.Domain.Entities;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasIndex(e => e.GenreName, "UQ_GenreName").IsUnique();

        builder.Property(e => e.GenreId).ValueGeneratedNever().HasColumnName("GenreID");
        builder.Property(e => e.GenreName).HasMaxLength(50).IsUnicode(false);
    }
}
