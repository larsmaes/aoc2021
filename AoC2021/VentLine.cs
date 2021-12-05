namespace AoC2021;

public struct VentLine
{
  public int X1 { get; init; }
  public int Y1 { get; init; }
  public int X2 { get; init; }
  public int Y2 { get; init; }

  public VentLine(int x1, int y1, int x2, int y2)
  {
    this.X1 = x1;
    this.Y1 = y1;
    this.X2 = x2;
    this.Y2 = y2;
  }
}