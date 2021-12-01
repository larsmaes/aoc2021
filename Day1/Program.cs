using AoC2021;

var depths = new List<int>();

foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
  depths.Add(Int32.Parse(line));
}

int depthIncreases = Sonar.depthIncreaseReport(depths);

System.Console.WriteLine($"Part 1: Number of depth increases: {depthIncreases}");

int depthIncreasesSlidingWindow = Sonar.depthIncreaseSlidingWindowReport(depths,3);

System.Console.WriteLine($"Part 2: Number of depth increases with sliding window: {depthIncreasesSlidingWindow}");
