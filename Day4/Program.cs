using AoC2021.Bingo;

string[] input = System.IO.File.ReadAllLines(@"input.txt");

int[] play = Array.ConvertAll(input[0].Split(","), s => int.Parse(s));


int inputLength = input.Length - 2;

List<Card> cardListPart1 = new();
List<Card> cardListPart2 = new();

for (int offset = 2; offset < inputLength; offset+=6)
{
  Number[,] cardNumbers = new Number[5,5];
  List<string> cardString = input.ToList().GetRange(offset, 5);
  for (int r = 0; r < 5; r++)
  {
    string line = cardString.ElementAt(r);
    int[] numbers = Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
    for (int c = 0; c < 5; c++)
    {
      Number num = new Number(numbers[c]);
      cardNumbers[r, c] = num;
    }
  }
  cardListPart1.Add(new Card(cardNumbers));
  cardListPart2.Add(new Card(cardNumbers));
}

Game bingo = new Game(cardListPart1);
System.Console.WriteLine($"Part 1: Sum of winning Card: { bingo.PlayTillFirstWin(play) }");
bingo = new Game(cardListPart2);
System.Console.WriteLine($"Part 2: Sum of losing Card: { bingo.PlayTillLastWin(play) }");
