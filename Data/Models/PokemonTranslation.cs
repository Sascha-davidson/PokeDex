using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonTranslation
{
    public int PokemonId { get; set; }

    public string Name { get; set; } = null!;

    public int LanguageCode { get; set; }

    public virtual Pokemon Pokemon { get; set; } = null!;
}
