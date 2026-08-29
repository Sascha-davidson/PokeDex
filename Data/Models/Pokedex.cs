using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Pokedex
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Game { get; set; } = null!;

    public string? Region { get; set; }

    public virtual ICollection<DexEntry> DexEntries { get; set; } = new List<DexEntry>();
}
