using StoreFilter.Infrastructure.Commons.Game.Request;

namespace StoreFilter.Application.DTO.Game.Request;

public class GameTypeFilterRequestDto
{
    public string? OrderBy { get; set; }
    public string? Name { get; set; }
    public DateTime? ReleaseDateBefore { get; set; }
    public DateTime? ReleaseDateAfter { get; set; }
    public decimal PriceMin { get; set; } = 0;
    public decimal? PriceMax { get; set; }
    public string Developer { get; set; } = string.Empty;
    public GamePlatform Platform { get; set; }
}
