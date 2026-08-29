using System.Collections.Generic;
using PokeDex.Data.Models;

namespace PokeDex.Backend.Models
{
    public partial class PokemonMaps
    {
        public int Id { get; set; }

        public int RegionId { get; set; }

        public string Name { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string? SvgPath { get; set; }

        public virtual ICollection<PokemonDroppedItem> PokemonDroppedItems { get; set; } = new List<PokemonDroppedItem>();

        public virtual PokemonRegion Region { get; set; } = null!;
    }

}
