using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class DexEntryTranslation
{
    public int ID { get; set; }

    public string language_code { get; set; } = null!;

    public string description { get; set; } = null!;

    public virtual DexEntry IDNavigation { get; set; } = null!;
}
