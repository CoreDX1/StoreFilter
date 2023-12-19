using Microsoft.EntityFrameworkCore;
using StoreFilter.Domain.Entities;
using StoreFilter.Infrastructure.Commons.Game.Request;
using StoreFilter.Infrastructure.Persistences.Context;

public class GamesRepository : IGamesRepository
{
    private readonly StoreGamesContext _context;

    public GamesRepository(StoreGamesContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Game>> GetGames()
    {
        IEnumerable<Game> games = await _context.Games.AsNoTracking().ToListAsync();
        return games;
    }

    public async Task<Game?> GetGame(Guid id)
    {
        var game = await _context.FindAsync<Game>(id);
        return game;
    }

    public async Task<IEnumerable<Game>> PostFilterGames(GameFilterProductsDto gameFilter)
    {
        var gameQuery = _context.Games.AsQueryable();

        if (!string.IsNullOrWhiteSpace(gameFilter.Name))
            gameQuery = gameQuery.Where(n => n.Name.ToLower().Contains(gameFilter.Name.ToLower()));

        if (gameFilter.Records)
            gameQuery = gameQuery.OrderBy(x => x.Name);

        if (gameFilter.ReleaseDateBefore != null && gameFilter.ReleaseDateAfter != null)
        {
            var releaseBefore = DateOnly.FromDateTime(gameFilter.ReleaseDateBefore.Value);
            var releaseAfter = DateOnly.FromDateTime(gameFilter.ReleaseDateAfter.Value);

            gameQuery = gameQuery.Where(
                x => x.ReleaseDate >= releaseBefore && x.ReleaseDate <= releaseAfter
            );
        }

        if (gameFilter.PriceMax != null)
        {
            gameQuery = gameQuery.Where(
                product =>
                    product.Price >= gameFilter.PriceMin && product.Price <= gameFilter.PriceMax
            );
        }

        var filteredGame = await gameQuery.ToListAsync();
        return filteredGame;
    }
}
