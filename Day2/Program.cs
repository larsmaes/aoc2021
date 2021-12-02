using AoC2021;

var movements = new List<Movement>();

foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
  var elements = line.Split(" ");
  movements.Add(new Movement{
    Direction=elements[0],
    Distance=Int32.Parse(elements[1])
  });
}

// Part 1
var submarine = new Submarine();

foreach (Movement m in movements)
{
  submarine.Move(m.Direction,m.Distance);
}

int horizontal = submarine.X;
int depth = submarine.Depth;

System.Console.WriteLine($"Part 1: Product of horizontal and depth: {horizontal*depth}");

// Part 2
submarine = new Submarine();

foreach (Movement m in movements)
{
  submarine.MoveWithAim(m.Direction,m.Distance);
}

horizontal = submarine.X;
depth = submarine.Depth;
System.Console.WriteLine($"Part 2: Product of horizontal and depth: {horizontal*depth}");
