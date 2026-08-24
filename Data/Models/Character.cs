using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Character
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public int? age { get; set; }

    public int? role_id { get; set; }

    public virtual CharactersRole? role { get; set; }
}
