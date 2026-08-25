using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Pokemon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NationalDexNumber { get; set; }

    public byte[]? Image { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<DexEntry> DexEntries { get; set; } = new List<DexEntry>();

    public virtual ICollection<PokemonForm> PokemonForms { get; set; } = new List<PokemonForm>();

    public virtual ICollection<PokemonTranslation> PokemonTranslations { get; set; } = new List<PokemonTranslation>();
}
