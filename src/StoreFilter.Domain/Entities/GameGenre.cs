namespace StoreFilter.Domain.Entities;

public partial class GameGenre
{
    public Guid GameId { get; set; }

    public int GenreId { get; set; }

    public virtual Game Game { get; set; } = null!;
}
