using System.Collections.Generic;
using Xunit;

namespace AoC2021.Tests;

public class SubmarineTest
{

  readonly List<Movement> movements = new(){
    new Movement("forward", 5),
    new Movement("down", 5),
    new Movement("forward", 8),
    new Movement("up", 3),
    new Movement("down", 8),
    new Movement("forward", 2),
  };

  readonly List<string> diagnostics = new(){
    "00100",
    "11110",
    "10110",
    "10111",
    "10101",
    "01111",
    "00111",
    "11100",
    "10000",
    "11001",
    "00010",
    "01010",
  };

  [Fact]
  public void TestSubmarineMovement()
  {

    var submarine = new Submarine();

    foreach (Movement m in movements)
    {
      submarine.Move(m.Direction, m.Distance);
    }

    int horizontal = submarine.X;
    int depth = submarine.Depth;

    Assert.Equal(150, horizontal * depth);

  }
  [Fact]
  public void TestSubmarineMovementWithAim()
  {

    var submarine = new Submarine();

    foreach (Movement m in movements)
    {
      submarine.MoveWithAim(m.Direction, m.Distance);
    }

    int horizontal = submarine.X;
    int depth = submarine.Depth;

    Assert.Equal(900, horizontal * depth);

  }

  [Fact]
  public void TestPowerConsumptionFromDiagnostics()
  {

    var submarine = new Submarine();

    submarine.ParseDiagnostics(diagnostics);

    int powerConsumtion = submarine.GammaRate * submarine.EpsilonRate;

    Assert.Equal(198, powerConsumtion);
  }

  [Fact]
  public void TestLifeSupportRatingFromDiagnostics()
  {

    var submarine = new Submarine();

    submarine.ParseDiagnostics(diagnostics);

    int LifeSupportRating = submarine.OxygenGeneratorRate * submarine.CO2ScrubberRate;

    Assert.Equal(230, LifeSupportRating);
  }

}