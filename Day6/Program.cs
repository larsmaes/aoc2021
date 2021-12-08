

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


var lines = System.IO.File.ReadLines(@"input.txt");

int[] nearbyLanternFishes = lines.ElementAt(0).Split(",").Select(Int32.Parse).ToArray();
// int[] nearbyLanternFishes = { 3, 4, 3, 1, 2 };

long[] countperDay = new long[9];

for (int i = 0; i < nearbyLanternFishes.Length; i++)
{
  countperDay[nearbyLanternFishes[i]]++;
}

countperDay.ToList().ForEach(i => Console.Write("{0} ", i));
Console.Write("\n");

for (int day = 0; day < 80; day++)
{
  long[] tempArray = new long[9];
  for (int i = 0; i < 9; i++)
  {
    tempArray[i] = countperDay[(i + 1)%9];
  }
  tempArray[6] += countperDay[0];
  tempArray[8] = countperDay[0];
  countperDay = tempArray;
  countperDay.ToList().ForEach(i => Console.Write("{0} ", i));
  Console.Write("\n");
}
Console.WriteLine($"Part 1: sum of nearby lanternfishes after 80 days: { countperDay.Sum() } ");