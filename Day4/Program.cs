using AoC2021.Bingo;

string[] input = System.IO.File.ReadAllLines(@"input.txt");

int[] play = Array.ConvertAll(input[0].Split(","), s => int.Parse(s));


int inputLength = input.Length - 2;

List<Board> boardListPart1 = new();
List<Board> boardListPart2 = new();

for (int offset = 2; offset < inputLength; offset+=6)
{
  Number[,] boardNumbers = new Number[5,5];
  List<string> boardString = input.ToList().GetRange(offset, 5);
  for (int r = 0; r < 5; r++)
  {
    string line = boardString.ElementAt(r);
    int[] numbers = Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
    for (int c = 0; c < 5; c++)
    {
      Number num = new(numbers[c]);
      boardNumbers[r, c] = num;
    }
  }
  boardListPart1.Add(new Board(boardNumbers));
  boardListPart2.Add(new Board(boardNumbers));
}

Game bingoPart1 = new(boardListPart1);
System.Console.WriteLine($"Part 1: Sum of winning Card: { bingoPart1.PlayTillFirstWin(play) }");
Game bingoPart2 = new(boardListPart2);
System.Console.WriteLine($"Part 2: Sum of losing Card: { bingoPart2.PlayTillLastWin(play) }");
