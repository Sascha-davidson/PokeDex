using PokeDex.Data.Models;

namespace PokeDex.Backend.Models
{
    public class PokemonGame
    {
        public int Id { get; set; }

        public int GenerationId { get; set; }

        public string Name { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public virtual PokemonGeneration Generation { get; set; } = null!;

        public virtual ICollection<PokemonDroppedItem> PokemonDroppedItems { get; set; } = new List<PokemonDroppedItem>();
    }
}
