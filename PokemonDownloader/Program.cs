using System.Net.Http.Json;
using System.Text.Json;

class PokemonDownloader
{
    static async Task Main()
    {
        var client = new HttpClient();
        var listUrl = "https://pokeapi.co/api/v2/pokemon?limit=2000&offset=0";

        var listResponse = await client.GetFromJsonAsync<PokemonListResponse>(listUrl);

        if (listResponse == null)
        {
            Console.WriteLine("Failed to get Pokémon list.");
            return;
        }

        var normalPokemon = new List<PokemonExport>();
        var megaPokemon = new List<PokemonExport>();
        int counter = 0;

        foreach (var item in listResponse.Results)
        {
            counter++;
            Console.WriteLine($"Fetching {counter}/{listResponse.Results.Count}: {item.Name}");

            var details = await client.GetFromJsonAsync<PokemonDetails>(item.Url);
            if (details == null) continue;

            // Get National Dex number
            var nationalDex = details.PokedexNumbers
                .FirstOrDefault(p => p.Pokedex.Name == "national")?.EntryNumber ?? details.Id;

            var export = new PokemonExport
            {
                Id = nationalDex,
                Name = details.Name,
                ImageUrl = details.Sprites.Other?.OfficialArtwork?.FrontDefault
                          ?? details.Sprites.Front_Default ?? "",
                Types = details.Types.Select(t => t.Type.Name).ToList()
            };

            if (details.IsDefault)
            {
                normalPokemon.Add(export); // base form
            }
            else if (details.Name.Contains("mega", StringComparison.OrdinalIgnoreCase))
            {
                megaPokemon.Add(export); // Mega Evolution
            }
        }

        // Save to wwwroot/data/
        var basePath = Path.Combine("..", "PokeDex", "wwwroot", "data");
        Directory.CreateDirectory(basePath);

        await File.WriteAllTextAsync(
            Path.Combine(basePath, "pokemon.json"),
            JsonSerializer.Serialize(normalPokemon.OrderBy(p => p.Id), new JsonSerializerOptions { WriteIndented = true })
        );

        await File.WriteAllTextAsync(
            Path.Combine(basePath, "pokemon-mega.json"),
            JsonSerializer.Serialize(megaPokemon.OrderBy(p => p.Id), new JsonSerializerOptions { WriteIndented = true })
        );

        Console.WriteLine("Saved base Pokémon to pokemon.json and Mega Evolutions to pokemon-mega.json!");
    }
}

// --- Models ---

public class PokemonListResponse
{
    public List<PokemonListItem> Results { get; set; } = new();
}

public class PokemonListItem
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
}

public class PokemonDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool IsDefault { get; set; } = true; // default form
    public Sprites Sprites { get; set; } = new();
    public List<PokemonType> Types { get; set; } = new();
    public List<PokedexNumber> PokedexNumbers { get; set; } = new();
}

public class PokedexNumber
{
    public int EntryNumber { get; set; }
    public PokedexInfo Pokedex { get; set; } = new();
}

public class PokedexInfo
{
    public string Name { get; set; } = "";
}

public class Sprites
{
    public string? Front_Default { get; set; }
    public OtherSprites? Other { get; set; }
}

public class OtherSprites
{
    public OfficialArtwork? OfficialArtwork { get; set; }
}

public class OfficialArtwork
{
    public string? FrontDefault { get; set; }
}

public class PokemonType
{
    public TypeInfo Type { get; set; } = new();
}

public class TypeInfo
{
    public string Name { get; set; } = "";
}

// Model for export
public class PokemonExport
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public List<string> Types { get; set; } = new();
}
