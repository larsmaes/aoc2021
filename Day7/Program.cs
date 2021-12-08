using AoC2021;

var lines = System.IO.File.ReadLines(@"input.txt");

int[] crabPositions = lines.ElementAt(0).Split(",").Select(Int32.Parse).ToArray();

System.Console.WriteLine($"Part1: Minimul fuel needed: { CrabSubMarine.CalculateLeastFuel(crabPositions) }");
System.Console.WriteLine($"Part1: Minimul fuel needed by crabs: { CrabSubMarine.CalculateLeastFuelAccordingToCrabs(crabPositions) }");
