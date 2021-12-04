namespace AoC2021.Bingo;

public class Card
{

  public Number[,] numbers { get; init; }
  public bool Won { get; private set; } = false;
  public Card(Number[,] numbers)
  {
    this.numbers = numbers;
  }

  public void MarkNumber(int number) 
  {
    for(int r=0; r<5; r++)
    {
      for (int c = 0; c < 5; c++)
      {
        if (numbers[r,c].Value == number)
        {
          numbers[r, c].Mark();
          DetermineWin();
        }
      }
    }
  }

  private void DetermineWin() 
  {
    if (fullRow() || fullColumn())
    {
      this.Won = true;
      
    } 
  }

  public int sumOfUnMarkedNumbers()
  {
    int sum = 0;
    for(int r=0; r<5; r++)
    {
      for (int c = 0; c < 5; c++)
      {
        if (!numbers[r,c].Marked)
        {
          sum+=numbers[r,c].Value;
        }
      }
    }
    return sum;
  }

  private bool fullRow() 
  {
    for(int r=0; r<5; r++)
    {
      bool fullyMarked = true;
      for (int c = 0; c < 5; c++)
      {
        if (!numbers[r,c].Marked)
        {
          fullyMarked = false;
        }
      }
      if (fullyMarked == true) return true;
    }
    return false;
  }

  private bool fullColumn()
  {
    for(int c=0; c<5; c++)
    {
      bool fullyMarked = true;
      for (int r = 0; r < 5; r++)
      {
        if (!numbers[r,c].Marked)
        {
          fullyMarked = false;
        }
      }
      if (fullyMarked == true) return true;
    }
    return false;
  }

}