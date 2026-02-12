using System;
using System.Text.Json.Serialization;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Height { get; set; }
    public int Weight { get; set; }

    public Sprites Sprites { get; set; } = new();
    public List<TypeSlot> Types { get; set; } = new();
}

public class Sprites
{
    public string? Front_Default { get; set; }
    public OtherSprites? Other { get; set; }
}

public class OtherSprites
{
    [JsonPropertyName("official-artwork")]
    public OfficialArtwork OfficialArtwork { get; set; } = new();
}

public class OfficialArtwork
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }
}

public class TypeSlot
{
    public TypeInfo Type { get; set; } = new();
}

public class TypeInfo
{
    public string Name { get; set; } = "";
}