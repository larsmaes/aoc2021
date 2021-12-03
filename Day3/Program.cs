using AoC2021;

var diagnostics = new List<string>();

foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
  diagnostics.Add(line);
}

Submarine submarine = new();

submarine.ParseDiagnostics(diagnostics);

System.Console.WriteLine($"Part 1: power consumtion = { submarine.GammaRate * submarine.EpsilonRate }");
System.Console.WriteLine($"Part 2: life support rating = { submarine.OxygenGeneratorRate * submarine.CO2ScrubberRate }");