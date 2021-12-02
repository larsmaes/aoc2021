using Xunit;
using System.Collections.Generic;

namespace AoC2021.Tests;

public class SubmarineTest
{

  List<Movement> movements = new List<Movement>{
    new Movement("forward", 5),
    new Movement("down", 5),
    new Movement("forward", 8),
    new Movement("up", 3),
    new Movement("down", 8),
    new Movement("forward", 2),
  };

  [Fact]
  public void TestSubmarineMovement()
  {
    
    var submarine = new Submarine();

    foreach (Movement m in movements)
    {
      submarine.Move(m.Direction,m.Distance);
    }

    int horizontal = submarine.X;
    int depth = submarine.Depth;

    Assert.Equal(150, horizontal*depth);

  }
  [Fact]
  public void TestSubmarineMovementWithAim()
  {
    
    var submarine = new Submarine();

    foreach (Movement m in movements)
    {
      submarine.MoveWithAim(m.Direction,m.Distance);
    }

    int horizontal = submarine.X;
    int depth = submarine.Depth;

    Assert.Equal(900, horizontal*depth);

  }

}