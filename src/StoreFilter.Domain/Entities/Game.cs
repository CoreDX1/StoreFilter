using System;
using System.Collections.Generic;

namespace StoreFilter.Domain.Entities;

public partial class Game
{
    public Guid GameId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? DeveloperId { get; set; }

    public double Rating { get; set; }

    public virtual Developer? Developer { get; set; }

    public virtual ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();

    public virtual ICollection<Platform> Platforms { get; set; } = new List<Platform>();
}
