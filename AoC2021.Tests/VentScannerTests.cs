using System.Collections.Generic;
using Xunit;

namespace AoC2021.Tests;

public class VentScannerTests
{

  readonly List<VentLine> ventLines = new()
  {
    new(0,9,5,9),
    new(8,0,0,8),
    new(9,4,3,4),
    new(2,2,2,1),
    new(7,0,7,4),
    new(6,4,2,0),
    new(0,9,2,9),
    new(3,4,1,4),
    new(0,0,8,8),
    new(5,5,8,2)
  };

  [Fact]
  public void TestOverlappingLines()
  {
    VentScanner v = new();

    v.Scan(ventLines);

    Assert.Equal(5,v.NumberOfOverlappingLines());
  }

  [Fact]
  public void TestOverlappingLinesWithDiagonals()
  {
    VentScanner v = new();

    v.ScanWithDiagonal(ventLines);

    Assert.Equal(12,v.NumberOfOverlappingLines());
  }
}