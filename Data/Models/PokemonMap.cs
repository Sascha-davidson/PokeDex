using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonMap
{
    public int Id { get; set; }

    public int RegionId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? SvgPath { get; set; }

    public int? GameId { get; set; }

    public virtual ICollection<PokemonDroppedItem> PokemonDroppedItems { get; set; } = new List<PokemonDroppedItem>();

    public virtual PokemonRegion Region { get; set; } = null!;
}
