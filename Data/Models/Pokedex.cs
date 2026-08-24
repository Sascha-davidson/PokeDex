using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Pokedex
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string game { get; set; } = null!;

    public string? region { get; set; }

    public virtual ICollection<DexEntry> DexEntries { get; set; } = new List<DexEntry>();
}
