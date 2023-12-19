using StoreFilter.Domain.Entities;
using StoreFilter.Infrastructure.Commons.Game.Request;

public interface IGamesRepository
{
    public Task<IEnumerable<Game>> GetGames();
    public Task<Game?> GetGame(Guid id);
    public Task<IEnumerable<Game>> PostFilterGames(GameFilterProductsDto gameFilter);
}
