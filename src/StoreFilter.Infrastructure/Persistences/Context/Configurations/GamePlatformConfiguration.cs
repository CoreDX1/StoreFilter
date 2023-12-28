using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFilter.Domain.Entities;

namespace StoreFilter.Infrastructure.Persistences.Context.Configurations;

public class GamePlatformConfiguration : IEntityTypeConfiguration<GamePlatform>
{
    public void Configure(EntityTypeBuilder<GamePlatform> builder)
    {
        builder.HasKey(e => new { e.GameId, e.PlatformId });

        builder.Property(e => e.GameId).HasColumnName("GameID");
        builder.Property(e => e.PlatformId).HasColumnName("PlatformID");
    }
}
