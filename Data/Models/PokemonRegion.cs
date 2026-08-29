using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonRegion
{
    public int Id { get; set; }

    public int GenerationId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public virtual PokemonGeneration Generation { get; set; } = null!;

    public virtual ICollection<PokemonMap> PokemonMaps { get; set; } = new List<PokemonMap>();
}
