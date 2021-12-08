using System.Linq;
using AoC2021;

var lines = System.IO.File.ReadLines(@"input.txt").Select(x => x).ToList();


Console.WriteLine($"Part 1: Number of 1,4,7 or 8: { SegmentDisplay.Calculate1478(lines) }");
Console.WriteLine($"Part 2: Sum of all digits: { SegmentDisplay.CalculateAll(lines) }");