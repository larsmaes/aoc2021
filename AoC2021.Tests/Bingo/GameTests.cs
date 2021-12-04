using System.Collections.Generic;
using AoC2021.Bingo;
using Xunit;

namespace AoC2021.Tests.Bingo;

public class GameTests
{

  readonly List<Board> BingoBoards = new()
  {
    new Board(new Number[,]
    {
      { new(22), new(13), new(17), new(11), new(0) },
      { new(8), new(2), new(23), new(4), new(24) },
      { new(21), new(9), new(14), new(16), new(7) },
      { new(6), new(10), new(3), new(18), new(5) },
      { new(1), new(12), new(20), new(15), new(19) }
    }),
    new Board(new Number[,]
    {
      { new(3), new (15), new(0), new(2), new(22) },
      { new(9), new(18), new(13), new(17), new(5) },
      { new(19), new(8), new(7), new(25), new(23) },
      { new(20), new(11), new(10), new(24), new(4) },
      { new(14), new(21), new(16), new(12), new(6) }
    }),
    new Board(new Number[,]
    {
      { new(14), new (21), new(17), new(24), new(4) },
      { new(10), new(16), new(15), new(9), new(19) },
      { new(18), new(8), new(23), new(26), new(20) },
      { new(22), new(11), new(13), new(6), new(5) },
      { new(2), new(0), new(12), new(3), new(7) }
    })
  };

  readonly int[] play = { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

  [Fact]
  public void TestWinningGameResult()
  {

    Game BingoGame = new(BingoBoards);

    int? WinningScore = BingoGame.PlayTillFirstWin(play);

    Assert.Equal(4512, WinningScore);
  }

  [Fact]
  public void TestLosingGameResult()
  {

    Game BingoGame = new(BingoBoards);

    int? WinningScore = BingoGame.PlayTillLastWin(play);

    Assert.Equal(1924, WinningScore);
  }

}