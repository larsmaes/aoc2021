using AoC2021;

var ventLines = new List<VentLine>();

foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
  var linePart = line.Split(" -> ");

  VentLine ventLine = new(
                int.Parse(linePart[0].Split(",")[0]),
                int.Parse(linePart[0].Split(",")[1]),
                int.Parse(linePart[1].Split(",")[0]),
                int.Parse(linePart[1].Split(",")[1])
  );

  ventLines.Add(ventLine);
}

VentScanner scanner = new();

scanner.Scan(ventLines);

System.Console.WriteLine($"Part 1: Number of overlapping vent lines: { scanner.NumberOfOverlappingLines() }");

scanner = new();

scanner.ScanWithDiagonal(ventLines);
System.Console.WriteLine($"Part 2: Number of overlapping vent lines: { scanner.NumberOfOverlappingLines() }");