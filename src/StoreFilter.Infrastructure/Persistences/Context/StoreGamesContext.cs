using Microsoft.EntityFrameworkCore;
using StoreFilter.Domain.Entities;

namespace StoreFilter.Infrastructure.Persistences.Context;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreGamesContext).Assembly);
    }
}
