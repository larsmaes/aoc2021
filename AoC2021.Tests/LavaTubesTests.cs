using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AoC2021.Tests;

public class LavaTubesTests
{

  private readonly ITestOutputHelper output;

  public LavaTubesTests(ITestOutputHelper output)
  {
    this.output = output;
  }
  int[,] area = new int[,]
  {
      { 2,1,9,9,9,4,3,2,1,0 },
      { 3,9,8,7,8,9,4,9,2,1 },
      { 9,8,5,6,7,8,9,8,9,2 },
      { 8,7,6,7,8,9,6,7,8,9 },
      { 9,8,9,9,9,6,5,6,7,8 }
  };

  [Fact]
  public void TestFindLowestPoint()
  {
    output.WriteLine($"Test out: { LavaTubes.FindLowestPoint(area) }");
    Assert.Equal(15, LavaTubes.FindLowestPoint(area));
  }

}