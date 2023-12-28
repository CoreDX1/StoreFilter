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
        IQueryable<Game> gameQuery = _context.Games.Include(x => x.Platforms).AsQueryable();

        if (!string.IsNullOrWhiteSpace(gameFilter.Name))
            gameQuery = gameQuery.Where(n => n.Name.ToLower().Contains(gameFilter.Name.ToLower()));

        gameQuery = gameFilter.OrderBy switch
        {
            "asc" => gameQuery.OrderBy(x => x.Name),
            "desc" => gameQuery.OrderByDescending(b => b.Name),
            _ => gameQuery
        };

        if (gameFilter.ReleaseDateBefore != null && gameFilter.ReleaseDateAfter != null)
        {
            var releaseBefore = DateOnly.FromDateTime(gameFilter.ReleaseDateBefore.Value);
            var releaseAfter = DateOnly.FromDateTime(gameFilter.ReleaseDateAfter.Value);

            gameQuery = gameQuery.Where(
                x => x.ReleaseDate >= releaseBefore && x.ReleaseDate <= releaseAfter
            );
        }

        // gameQuery = gameFilter.Platform switch
        // {
        //     "pc" => gameQuery.FirstOrDefault(x => x.Platforms.Count == 1),
        //     _ => gameQuery
        // };

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
