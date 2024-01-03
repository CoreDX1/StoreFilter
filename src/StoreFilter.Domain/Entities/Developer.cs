namespace StoreFilter.Domain.Entities;

public partial class Developer
{
    public int DeveloperId { get; set; }

    public string DeveloperName { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
