namespace AoC2021.Bingo;

public class Game
{

  private readonly List<Board> BingoBoards;

  public Game(List<Board> boards)
  {
    this.BingoBoards = boards;
  }

  public int? PlayTillFirstWin(int[] numbers)
  {
    foreach (int i in numbers)
    {
      foreach (Board board in BingoBoards)
      {
        board.MarkNumber(i);
        if (board.Won)
        {
          return board.SumOfUnMarkedNumbers() * i;
        }
      }
    }
    return null;
  }

  public int? PlayTillLastWin(int[] numbers)
  {
    int NumberOfBoards = BingoBoards.Count;
    int wonBoards = 0;
    foreach (int i in numbers)
    {
      foreach (Board board in BingoBoards)
      {
        if (!board.Won)
        {
          board.MarkNumber(i);
          if (board.Won)
          {
            wonBoards++;
            if (wonBoards == NumberOfBoards)
            {
              return board.SumOfUnMarkedNumbers() * i;
            }
          }
        }
      }
    }
    return null;
  }




}