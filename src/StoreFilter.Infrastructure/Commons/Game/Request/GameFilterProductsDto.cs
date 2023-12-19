namespace StoreFilter.Infrastructure.Commons.Game.Request;

public enum GamePlatform
{
    All,
    PC,
    PS4,
    XBOX
}

public class GameFilterProductsDto
{
    public string? OrderBy { get; set; }
    public string? Name { get; set; }
    public DateTime? ReleaseDateBefore { get; set; }
    public DateTime? ReleaseDateAfter { get; set; }
    public decimal PriceMin { get; set; } = 0;
    public decimal? PriceMax { get; set; }
    public string Developer { get; set; } = string.Empty;
    public GamePlatform Platform { get; set; }

    public bool Records
    {
        set => OrderBy = value ? "asc" : "desc";
        get => OrderBy == "asc";
    }
}
