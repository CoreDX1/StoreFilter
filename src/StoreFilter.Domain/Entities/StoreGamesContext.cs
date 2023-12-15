using Microsoft.EntityFrameworkCore;

namespace StoreFilter.Domain.Entities;

public partial class StoreGamesContext : DbContext
{
    public StoreGamesContext() { }

    public StoreGamesContext(DbContextOptions<StoreGamesContext> options)
        : base(options) { }

    public virtual DbSet<Developer> Developers { get; set; }
    public virtual DbSet<Game> Games { get; set; }
    public virtual DbSet<GameGenre> GameGenres { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Platform> Platforms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=StoreGames;TrustServerCertificate=True;User id=sa;Password=index#12345"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>(entity =>
        {
            entity.HasIndex(e => e.DeveloperName, "UQ_DeveloperName").IsUnique();

            entity.Property(e => e.DeveloperId).ValueGeneratedNever().HasColumnName("DeveloperID");
            entity.Property(e => e.DeveloperName).HasMaxLength(100).IsUnicode(false);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_GameName").IsUnique();

            entity.Property(e => e.GameId).HasDefaultValueSql("(newid())").HasColumnName("GameID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");
            entity
                .Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity
                .HasOne(d => d.Developer)
                .WithMany(p => p.Games)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("FK_Games_Developers");

            entity
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
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(e => new { e.GameId, e.GenreId });

            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");

            entity
                .HasOne(d => d.Game)
                .WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameGenres_Games");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasIndex(e => e.GenreName, "UQ_GenreName").IsUnique();

            entity.Property(e => e.GenreId).ValueGeneratedNever().HasColumnName("GenreID");
            entity.Property(e => e.GenreName).HasMaxLength(50).IsUnicode(false);
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasIndex(e => e.PlatformName, "UQ_Platforms").IsUnique();

            entity.HasIndex(e => e.PlatformName, "UQ__Platform__85614BEE4AD4F741").IsUnique();

            entity
                .Property(e => e.PlatformId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PlatformID");
            entity.Property(e => e.PlatformName).HasMaxLength(50).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
