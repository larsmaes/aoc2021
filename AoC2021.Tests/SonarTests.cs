using System.Collections.Generic;
using Xunit;

namespace AoC2021.Tests;

public class SonarTest
{

  private readonly List<int> depths = new() {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };

  [Fact]
  public void TestDepthIncreaseReport()
  {

    var result = Sonar.DepthIncreaseReport(depths);

    Assert.Equal(7, result);
  }

  [Fact]
  public void TestDepthIncreaseReportSlidingWindow()
  {

    var result = Sonar.DepthIncreaseSlidingWindowReport(depths,3);

    Assert.Equal(5, result);
  }
}