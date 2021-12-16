using System.Linq;
using AoC2021;

var lines = System.IO.File.ReadLines(@"input.txt").ToList();

int[,] area = new int[100,100];

for(int l=0;l<lines.Count();l++)
{
	var c = lines[l].ToCharArray();
	for(int b=0; b<c.Length; b++)
	{
	area[l,b]=(int)Char.GetNumericValue(c[b]);
	}
}

Console.WriteLine($"Part 1: Sum of lowest point { LavaTubes.FindLowestPoint(area) }");
