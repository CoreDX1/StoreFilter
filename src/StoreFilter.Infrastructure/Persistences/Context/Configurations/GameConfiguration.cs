using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFilter.Domain.Entities;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasIndex(e => e.Name, "UQ_GameName").IsUnique();

        builder.Property(e => e.GameId).HasDefaultValueSql("(newid())").HasColumnName("GameID");
        builder.Property(e => e.Description).IsUnicode(false);
        builder.Property(e => e.DeveloperId).HasColumnName("DeveloperID");
        builder
            .Property(e => e.ImageUrl)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("ImageURL");
        builder.Property(e => e.Name).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Price).HasColumnType("decimal(10, 2)");

        builder
            .HasOne(d => d.Developer)
            .WithMany(p => p.Games)
            .HasForeignKey(d => d.DeveloperId)
            .HasConstraintName("FK_Games_Developers");

        builder
            .HasMany(d => d.Platforms)
            .WithMany(p => p.Games)
            .UsingEntity<Dictionary<string, object>>(
                "GamePlatform",
                r =>
                    r.HasOne<Platform>()
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GamePlatforms_Platforms"),
                l =>
                    l.HasOne<Game>()
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GamePlatforms_Games"),
                j =>
                {
                    j.HasKey("GameId", "PlatformId");
                    j.ToTable("GamePlatforms");
                    j.IndexerProperty<Guid>("GameId").HasColumnName("GameID");
                    j.IndexerProperty<Guid>("PlatformId").HasColumnName("PlatformID");
                }
            );
    }
}
