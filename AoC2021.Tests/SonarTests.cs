using Xunit;
using System.Collections.Generic;

namespace AoC2021.Tests;

public class SonarTest
{

  private List<int> depths = new List<int> {
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
    var sonar = new Sonar();

    var result = sonar.depthIncreaseReport(depths);

    Assert.Equal(7, result);
  }

  [Fact]
  public void TestDepthIncreaseReportSlidingWindow()
  {
    var sonar = new Sonar();

    var result = sonar.depthIncreaseSlidingWindowReport(depths,3);

    Assert.Equal(5, result);
  }
}