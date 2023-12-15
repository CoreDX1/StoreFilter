namespace Store.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGamesRepository Game { get; }
        void SaveChagens();
        Task SaveChagensAsync();
    }
}
