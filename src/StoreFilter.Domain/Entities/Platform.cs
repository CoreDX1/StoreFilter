namespace StoreFilter.Domain.Entities;

public partial class Platform
{
    public Guid PlatformId { get; set; }

    public string PlatformName { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
