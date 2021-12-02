using Xunit;
using System.Collections.Generic;

namespace AoC2021.Tests;

public class SubmarineTest
{

  List<Movement> movements = new List<Movement>{
    new Movement
    { 
      Direction="forward", 
      Distance=5
    },
    new Movement
    { 
      Direction="down", 
      Distance=5
    },
    new Movement
    { 
      Direction="forward", 
      Distance=8
    },
    new Movement
    { 
      Direction="up", 
      Distance=3
    },
    new Movement
    { 
      Direction="down", 
      Distance=8
    },
    new Movement
    { 
      Direction="forward", 
      Distance=2
    },
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