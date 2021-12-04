namespace AoC2021.Bingo;

public class Number
{
  public int Value { get; init; }
  public bool Marked { get; private set; } = false;


  public Number(int number)
  {
    this.Value = number;
  }
  public void Mark() {
    this.Marked = true;
  }
}