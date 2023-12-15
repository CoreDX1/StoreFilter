using StoreFilter.Domain.Entities;

public interface IGamesRepository
{
    public Task<IEnumerable<Game>> GetGames();
}
