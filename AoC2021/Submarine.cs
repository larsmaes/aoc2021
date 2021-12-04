using System.Linq;
using System.Text;

namespace AoC2021;

public class Submarine
{

  public int X { get; private set; } = 0;
  public int Z { get; private set; } = 0;
  public int Aim { get; private set; } = 0;

  public int GammaRate { get; private set; } = 0;
  public int EpsilonRate { get; private set; } = 0;

  public int OxygenGeneratorRate { get; private set; } = 0;
  public int CO2ScrubberRate { get; private set; } = 0;


  public int Depth
  {
    get
    {
      return Math.Abs(Z);
    }
  }

  /// <summary> This will move the submarine in the given direction for the distance given </summary>
  /// <param name="Direction">The direction which can be one of
  ///   <list type="bullet">
  ///     <item>forward</item>
  ///     <item>down</item>
  ///     <item>up</item>
  ///   </list>
  /// </param>
  /// <param name="Distance">The distance</param>
  [Obsolete("Move is wrong, please use MoveWithAim")]
  public void Move(string direction, int distance)
  {
    switch (direction)
    {
      case "forward":
        this.X += distance;
        break;
      case "down":
        this.Z -= distance;
        break;
      case "up":
        this.Z += distance;
        break;
    }
  }

  public void MoveWithAim(string direction, int distance)
  {
    switch (direction)
    {
      case "forward":
        this.X += distance;
        this.Z -= distance * Aim;
        break;
      case "down":
        this.Aim += distance;
        break;
      case "up":
        this.Aim -= distance;
        break;
    }
  }

  public void ParseDiagnostics(List<string> diagnostics)
  {

    // Part 1
    List<string> pivotDiagnostics = PivotDiagnostics(diagnostics);
    var (commonBits, leastCommonBits) = DetermineMostAndLeastCommonBits(pivotDiagnostics);

    this.GammaRate = Convert.ToInt32(commonBits.ToString(), 2);
    this.EpsilonRate = Convert.ToInt32(leastCommonBits.ToString(), 2);

    // Part 2
    this.OxygenGeneratorRate = DiagnosticsRatingByCriteria(new(diagnostics), SearchCriteria.CommonBit);
    this.CO2ScrubberRate = DiagnosticsRatingByCriteria(new(diagnostics), SearchCriteria.LeastCommonBit);
  }

  private static List<string> PivotDiagnostics(List<string> diagnostics)
  {
    List<string> parsedDiagnostics = new();

    int iterations = (diagnostics.First<string>()).Length;
    for (int i = 0; i < iterations; i++)
    {
      StringBuilder diagnosticPivot = new();
      foreach (string line in diagnostics)
      {
        diagnosticPivot.Append(line[i]);
      }
      parsedDiagnostics.Add(diagnosticPivot.ToString());
    }

    return parsedDiagnostics;
  }

  private static (string, string) DetermineMostAndLeastCommonBits(List<string> bitlist)
  {
    StringBuilder commonBits = new();
    StringBuilder leastCommonBits = new();
    foreach (string p in bitlist)
    {
      (char commonBit, char leastCommonBit) = DetermineMostAndLeastCommonBit(p);
      commonBits.Append(commonBit);
      leastCommonBits.Append(leastCommonBit);
    }

    return (commonBits.ToString(), leastCommonBits.ToString());
  }

  private static (char, char) DetermineMostAndLeastCommonBit(string bits)
  {
    int ones = bits.Count(f => (f == '1'));
    int zeros = bits.Count(f => (f == '0'));

    return (ones >= zeros ? '1' : '0', ones < zeros ? '1' : '0');
  }

  private static int DiagnosticsRatingByCriteria(List<string> diagnosticlist, SearchCriteria crit)
  {
    int iterations = (diagnosticlist.First<string>()).Length;
    for (int i = 0; i < iterations && diagnosticlist.Count > 1; i++)
    {
      var pivot = PivotDiagnostics(diagnosticlist);
      (char commonBit, char leastCommonBit) = DetermineMostAndLeastCommonBit(pivot.ElementAt(i));
      diagnosticlist = (from l in diagnosticlist
                        where l[i] == (crit == SearchCriteria.CommonBit ? commonBit : leastCommonBit)
                        select l).ToList();
    }
    return Convert.ToInt32(diagnosticlist.ElementAt(0), 2);

  }


}