using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonForm
{
    public int FormId { get; set; }

    public int PokemonId { get; set; }

    public int FormType { get; set; }

    public int? Region { get; set; }

    public int FirstType { get; set; }

    public int? SecondType { get; set; }

    public bool IsDefault { get; set; }

    public byte[]? Image { get; set; }

    public virtual Pokemon Pokemon { get; set; } = null!;
}
