using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? RoleId { get; set; }

    public virtual CharactersRole? Role { get; set; }
}
