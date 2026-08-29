namespace PokeDex.Backend.Models
{
    public class PokemonGeneration
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool HasMap { get; set; }
        public string Slug { get; set; } = null!;

    }
}
