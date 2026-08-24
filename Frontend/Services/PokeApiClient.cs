using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PokeDex.FrontEnd.Services;

public class PokeApiClient
{
    private readonly HttpClient _httpClient;

    public PokeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PokemonListResponse> GetPokemonListAsync(int limit, int offset)
    {
        var response = await _httpClient.GetFromJsonAsync<PokemonListResponse>(
            $"pokemon?limit={limit}&offset={offset}");

        return response ?? new PokemonListResponse();
    }

    public async Task<PokemonDetails> GetPokemonAsync(string nameOrId)
    {
        var response = await _httpClient.GetFromJsonAsync<PokemonDetails>($"pokemon/{nameOrId}");

        return response ?? throw new InvalidOperationException($"Could not load Pokémon '{nameOrId}'.");
    }
}

public class PokemonListResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<PokemonListItem> Results { get; set; } = new();
}

public class PokemonListItem
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

public class PokemonDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PokemonSprites Sprites { get; set; } = new();
    public List<PokemonTypeSlot> Types { get; set; } = new();
}

public class PokemonSprites
{
    public string? Front_Default { get; set; }
    public PokemonSpritesOther? Other { get; set; }
}

public class PokemonSpritesOther
{
    [JsonPropertyName("official-artwork")]
    public OfficialArtwork OfficialArtwork { get; set; } = new();
}

public class OfficialArtwork
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }
}

public class PokemonTypeSlot
{
    public int Slot { get; set; }
    public PokemonTypeInfo Type { get; set; } = new();
}

public class PokemonTypeInfo
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
