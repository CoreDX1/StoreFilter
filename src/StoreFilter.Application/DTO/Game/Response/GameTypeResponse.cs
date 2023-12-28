namespace StoreFilter.Application.DTO.Game.Response;

public class GameTypeResponse
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
}
