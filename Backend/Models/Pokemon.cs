namespace PokeDex.Backend.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int NationalDexNumber { get; set; }
    public string? ImageUrl { get; set; }
    public List<string> Types { get; set; } = new();
}