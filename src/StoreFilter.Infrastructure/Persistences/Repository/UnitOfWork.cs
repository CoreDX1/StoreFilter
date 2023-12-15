using Store.Infrastructure.Persistences.Interfaces;
using StoreFilter.Infrastructure.Persistences.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreGamesContext _context;

    public IGamesRepository Game { get; private set; }

    public UnitOfWork(StoreGamesContext context, IGamesRepository game)
    {
        _context = context;
        Game = new GamesRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChagens()
    {
        _context.SaveChanges();
    }

    public async Task SaveChagensAsync()
    {
        await _context.SaveChangesAsync();
    }
}
