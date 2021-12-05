using System;

namespace AoC2021;

public class VentScanner
{

  const int x = 1000;
  const int y = 1000;
  public int[,] grid = new int[x, y];

  public void Scan(List<VentLine> ventLines)
  {
    var hLines = from v in ventLines
                 where v.Y1 == v.Y2
                 select v;

    var vLines = from v in ventLines
                 where v.X1 == v.X2
                 select v;

    foreach (VentLine v in hLines)
    {
      PlotHorizontalLine(v);
    }

    foreach (VentLine v in vLines)
    {
      PlotVerticalLine(v);
    }

  }

  public void ScanWithDiagonal(List<VentLine> ventLines)
  {
    Scan(ventLines);

    var dLines = from v in ventLines
                 where (v.X1 != v.X2) && (v.Y1 != v.Y2)
                 select v;

    foreach (VentLine v in dLines)
    {
      PlotDiagonalLine(v);
    }

  }

  public int NumberOfOverlappingLines()
  {
    int count = 0;

    for (int r = 0; r < x; r++)
    {
      for (int c = 0; c < y; c++)
      {
        if (this.grid[r, c] > 1) count++;
      }
    }

    return count;
  }

  private void PlotVerticalLine(VentLine v)
  {
    int length = Math.Abs(v.Y1 - v.Y2);

    int start = v.Y1 < v.Y2 ? v.Y1 : v.Y2;
    for (int i = 0; i <= length; i++)
    {
      this.grid[v.X1, start + i]++;
    }
  }

  private void PlotHorizontalLine(VentLine v)
  {
    int length = Math.Abs(v.X1 - v.X2);

    int start = v.X1 < v.X2 ? v.X1 : v.X2;
    for (int i = 0; i <= length; i++)
    {
      this.grid[start + i, v.Y1]++;
    }
  }

  private void PlotDiagonalLine(VentLine v)
  {
    int length = Math.Abs(v.X1 - v.X2);

    if (v.X1 < v.X2)
    {
      if (v.Y1 < v.Y2)
      {
        for (int i = 0; i <= length; i++)
        {
          this.grid[v.X1 + i, v.Y1 + i]++;
        }
      }
      else
      {
        for (int i = 0; i <= length; i++)
        {
          this.grid[v.X1 + i, v.Y1 - i]++;
        }
      }
    }
    else
    {
      if (v.Y1 < v.Y2)
      {
        for (int i = 0; i <= length; i++)
        {
          this.grid[v.X1 - i, v.Y1 + i]++;
        }
      }
      else
      {
        for (int i = 0; i <= length; i++)
        {
          this.grid[v.X1 - i, v.Y1 - i]++;
        }
      }
    }
  }


}