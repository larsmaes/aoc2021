using System.Linq;
using AoC2021;

var lines = System.IO.File.ReadLines(@"input.txt").ToList();

Console.WriteLine($"Part 1: Corrupted Lines Score:  { SyntaxScoring.CorruptLinesScore(lines) }");
Console.WriteLine($"Part 2: Incomplete Lines Score:  { SyntaxScoring.IncompleteLinesScore(lines) }");
