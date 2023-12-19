using StoreFilter.Domain.Entities;

public interface IGamesRepository
{
    public Task<IEnumerable<Game>> GetGames();
    public Task<Game?> GetGame(Guid id);
    public Task<IEnumerable<Genre>> PostFilterGames();
}
