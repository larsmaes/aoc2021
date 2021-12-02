namespace AoC2021;

public readonly struct Movement
{
  public Movement(string direction, int distance)
  {
    Direction = direction;
    Distance = distance;
  }

  public string Direction { get; init; }
  public int Distance { get; init; }

}
