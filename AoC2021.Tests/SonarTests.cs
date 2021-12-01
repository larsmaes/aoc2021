using Xunit;
using System.Collections.Generic;

namespace AoC2021.Tests;

public class SonarTest
{
    [Fact]
    public void TestDepthIncreaseReport()
    {
        var depths = new List<int> {
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
        var sonar = new Sonar();

        var result = sonar.depthIncreaseReport(depths);

        Assert.Equal(7,result);
    }
}