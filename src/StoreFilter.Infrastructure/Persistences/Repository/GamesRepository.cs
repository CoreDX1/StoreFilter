using Microsoft.EntityFrameworkCore;
using StoreFilter.Domain.Entities;
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
        IEnumerable<Game> games = await _context.Games.ToListAsync();
        return games;
    }
}
