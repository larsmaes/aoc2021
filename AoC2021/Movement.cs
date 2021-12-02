namespace AoC2021;

public record Movement
{
    public string Direction{ get; init; } = default!;
    public int Distance { get; init; } = default!;
};