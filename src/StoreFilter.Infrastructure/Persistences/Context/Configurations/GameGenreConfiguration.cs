using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFilter.Domain.Entities;

public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
{
    public void Configure(EntityTypeBuilder<GameGenre> builder)
    {
        builder.HasKey(e => new { e.GameId, e.GenreId });

        builder.Property(e => e.GameId).HasColumnName("GameID");
        builder.Property(e => e.GenreId).HasColumnName("GenreID");

        builder
            .HasOne(d => d.Game)
            .WithMany(p => p.GameGenres)
            .HasForeignKey(d => d.GameId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_GameGenres_Games");
    }
}
