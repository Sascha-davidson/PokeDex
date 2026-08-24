using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonTranslation
{
    public int pokemon_id { get; set; }

    public string name { get; set; } = null!;

    public int language_code { get; set; }

    public virtual Pokemon pokemon { get; set; } = null!;
}
