namespace AoC2021.Bingo;

public class Board
{

  public Number[,] Numbers { get; init; }
  public bool Won { get; private set; } = false;
  public Board(Number[,] numbers)
  {
    this.Numbers = numbers;
  }

  public void MarkNumber(int number)
  {
    for (int r = 0; r < 5; r++)
    {
      for (int c = 0; c < 5; c++)
      {
        if (Numbers[r, c].Value == number)
        {
          Numbers[r, c].Mark();
          DetermineWin();
        }
      }
    }
  }

  private void DetermineWin()
  {
    if (FullRow() || FullColumn())
    {
      this.Won = true;
    }
  }

  public int SumOfUnMarkedNumbers()
  {
    int sum = 0;
    for (int r = 0; r < 5; r++)
    {
      for (int c = 0; c < 5; c++)
      {
        if (!Numbers[r, c].Marked)
        {
          sum += Numbers[r, c].Value;
        }
      }
    }
    return sum;
  }

  private bool FullRow()
  {
    for (int r = 0; r < 5; r++)
    {
      bool fullyMarked = true;
      for (int c = 0; c < 5; c++)
      {
        if (!Numbers[r, c].Marked)
        {
          fullyMarked = false;
        }
      }
      if (fullyMarked == true) return true;
    }
    return false;
  }

  private bool FullColumn()
  {
    for (int c = 0; c < 5; c++)
    {
      bool fullyMarked = true;
      for (int r = 0; r < 5; r++)
      {
        if (!Numbers[r, c].Marked)
        {
          fullyMarked = false;
        }
      }
      if (fullyMarked == true) return true;
    }
    return false;
  }

}