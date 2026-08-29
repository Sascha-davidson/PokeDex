using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class DexEntry
{
    public int Id { get; set; }

    public int PokemonId { get; set; }

    public int PokedexId { get; set; }

    public int DexNumber { get; set; }

    public virtual ICollection<DexEntryTranslation> DexEntryTranslations { get; set; } = new List<DexEntryTranslation>();

    public virtual Pokedex Pokedex { get; set; } = null!;

    public virtual Pokemon Pokemon { get; set; } = null!;
}
