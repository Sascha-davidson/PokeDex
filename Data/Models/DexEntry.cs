using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class DexEntry
{
    public int id { get; set; }

    public int pokemon_id { get; set; }

    public int pokedex_id { get; set; }

    public int dex_number { get; set; }

    public virtual ICollection<DexEntryTranslation> DexEntryTranslations { get; set; } = new List<DexEntryTranslation>();

    public virtual Pokedex pokedex { get; set; } = null!;

    public virtual Pokemon pokemon { get; set; } = null!;
}
