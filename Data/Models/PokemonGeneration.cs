using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonGeneration
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public bool HasMap { get; set; }

    public virtual ICollection<PokemonGame> PokemonGames { get; set; } = new List<PokemonGame>();

    public virtual ICollection<PokemonRegion> PokemonRegions { get; set; } = new List<PokemonRegion>();
}
