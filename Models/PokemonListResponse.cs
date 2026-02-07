using System;

public class PokemonListResponse
{
    public int Count { get; set; }
    public List<PokemonListItem> Results { get; set; } = [];
}

public class PokemonListItem
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
}