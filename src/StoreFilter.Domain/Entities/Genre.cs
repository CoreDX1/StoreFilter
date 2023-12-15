using System;
using System.Collections.Generic;

namespace StoreFilter.Domain.Entities;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;
}
