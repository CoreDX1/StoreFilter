namespace StoreFilter.Application.DTO.Game.Request;

public record GameTypeFilterRequestDto(
    string? OrderBy,
    string? Name,
    DateTime? ReleaseDateBefore,
    DateTime? ReleaseDateAfter,
    decimal PriceMin,
    decimal? PriceMax,
    string? Developer
);
