using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class DexEntryTranslation
{
    public int Id { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual DexEntry IdNavigation { get; set; } = null!;
}
