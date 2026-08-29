using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class CharactersRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
