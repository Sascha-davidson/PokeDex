using System;
using System.Net.Http.Json;

public class PokeApiClient
{
    private readonly HttpClient _http;

    public PokeApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<PokemonListResponse?> GetPokemonListAsync(
        int limit = 20,
        int offset = 0)
    {
        return await _http.GetFromJsonAsync<PokemonListResponse>(
            $"pokemon?limit={limit}&offset={offset}");
    }

    public async Task<Pokemon?> GetPokemonAsync(string name)
    {
        return await _http.GetFromJsonAsync<Pokemon>($"pokemon/{name}");
    }
}
