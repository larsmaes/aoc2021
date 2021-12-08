using System.Collections.Generic;
using Xunit;

namespace AoC2021.Tests;

public class CrabSubmarineTests
{


  [Fact]
  public void TestCalculateLeastFuel()
  {

    int[] crabPositions = { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

    Assert.Equal(37, CrabSubMarine.CalculateLeastFuel(crabPositions));

  }

  [Fact]
  public void TestCalculateLeastFuelAccordingToCrabs()
  {

    int[] crabPositions = { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

    Assert.Equal(168, CrabSubMarine.CalculateLeastFuelAccordingToCrabs(crabPositions));

  }

  
}
