using System.Runtime.CompilerServices;

namespace AoC2021;

public class LavaTubes
{

  public static int FindLowestPoint(int[,] area)
  {
    int sum = 0;
    for (int y = 0; y < area.GetLength(0); y++)
    {
      for (int x = 0; x < area.GetLength(1); x++)
      {

        int v = area[y, x];
        int left = x - 1 >= 0 ? area[y, x - 1] : 9;
        int right = x + 1 <= area.GetLength(1) - 1 ? area[y, x + 1] : 9;
        int down = y - 1 >= 0 ? area[y - 1, x] : 9;
        int up = y + 1 <= area.GetLength(0) - 1 ? area[y + 1, x] : 9;

        if (left > v && right > v && down > v && up > v)
        {
          sum += v+1;
        }
      }
    }
    return sum;
  }
}