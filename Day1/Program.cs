var depths = new List<int>();

foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
  depths.Add(Int32.Parse(line));
}

var sonar = new AoC2021.Sonar();

int depthIncreases = sonar.depthIncreaseReport(depths);

System.Console.WriteLine($"Part1: Number of depth increases: {depthIncreases}");
