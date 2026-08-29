using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonDroppedItem
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int MapId { get; set; }

    public string ItemName { get; set; } = null!;

    public double X { get; set; }

    public double Y { get; set; }

    public virtual PokemonGame Game { get; set; } = null!;

    public virtual PokemonMap Map { get; set; } = null!;
}
