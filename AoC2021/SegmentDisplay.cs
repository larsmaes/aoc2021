using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace AoC2021;

public class SegmentDisplay
{

  public static int Calculate1478(List<string> signals)
  {

    return signals.Select(s => s.Split(" | ")[1])
              .SelectMany(a => a.Split(" "))
              .GroupBy(x => x.Length)
              .Where(b => b.Key == 2 || b.Key == 4 || b.Key == 3 || b.Key == 7)
              .Select(h => h.Count()).Sum();

  }

  // 7 - 1 = top (a)
  // 8 - 4 - top = bottom + bottom left (e+g)
  // 6 = 0 , 9 , 6 == als 8 - x = in 1 dan 6 => 8 - 6 = top right (c)
  // 1 - c = f
  // 9 = als x - 4 aantal = 2 dan 9 = 8 - 9 = bottom left (e)
  // 8 - 4 - top - bottom left = bottom (g)
  // 0 is wat over blijft dus 8 - 0 is middle (d)
  // 8 - acdefg = b 
  // 
  // 5 = 5 , 2 , 3

  public static int CalculateAll(List<string> signals)
  {
    int result = 0;
    foreach (var signal in signals)
    {

      var signalParts = signal.Split(" | ");

      var orderedSignals = signalParts[0]
                  .Split(" ")
                  .GroupBy(x => x.Length);

      var testsignal = orderedSignals.SelectMany(x => x);


      List<string> sortedSignals = new();
      testsignal.ToList().ForEach(s => sortedSignals.Add(new string(s.ToCharArray()
                      .OrderBy(c => c)
                      .ToArray())));

      var segments = new Dictionary<string, int>();



      segments.Add(determineOne(sortedSignals), 1);
      segments.Add(determineFour(sortedSignals), 4);
      segments.Add(determineSeven(sortedSignals), 7);
      segments.Add(determineEight(sortedSignals), 8);
      segments.Add(determineNine(sortedSignals), 9);
      segments.Add(determineSix(sortedSignals), 6);
      segments.Add(determineZero(sortedSignals), 0);
      segments.Add(determineFive(sortedSignals), 5);
      segments.Add(determineTwo(sortedSignals), 2);
      segments.Add(determineThree(sortedSignals), 3);

      //segments.Add('2', determineTwo(testsignal));
      //segments.Add('3', determineThree(testsignal));


      var orderedDigits = signalParts[1]
                  .Split(" ");

      //var testDigit = orderedDigits.SelectMany(x => x);


      List<string> sortedDigits = new();
      orderedDigits.ToList().ForEach(s => sortedDigits.Add(new string(s.ToCharArray()
                      .OrderBy(c => c)
                      .ToArray())));

      List<int> digits = new();

      StringBuilder digitString = new();
      foreach (var d in sortedDigits)
      {
        digitString.Append(segments.GetValueOrDefault(d));
      }
      result += int.Parse(digitString.ToString());
    }

    return result;

  }

  private static string determineOne(List<string> signals)
  {
    return new string(signals.FindByLength(2).SingleOrderCharArray());
  }

  private static string determineFour(List<string> signals)
  {
    return new string(signals.FindByLength(4).SingleOrderCharArray());
  }

  private static string determineSeven(List<string> signals)
  {
    return new string(signals.FindByLength(3).SingleOrderCharArray());
  }

  private static string determineEight(List<string> signals)
  {
    return new string(signals.FindByLength(7).SingleOrderCharArray());
  }

  private static string determineNine(List<string> signals)
  {
    var four = determineFour(signals);
    var seven = determineSeven(signals);
    var f = signals.FindByLength(6);
    var g = f.Where(a => a.Except(four).Except(seven).Count() == 1);
    return new string(g.SingleOrderCharArray());
  }

  private static string determineSix(List<string> signals)
  {
    var one = determineOne(signals);
    var nine = determineNine(signals);
    var f = signals.FindByLength(6);
    var g = f.Where(a => a != nine && one.Except(a).Count() == 1);
    return new string(g.SingleOrderCharArray());
  }

  private static string determineZero(List<string> signals)
  {
    var six = determineSix(signals);
    var nine = determineNine(signals);
    var f = signals.FindByLength(6);
    var g = f.Where(a => a != six && a != nine);
    return new string(g.SingleOrderCharArray());
  }

  private static string determineE(List<string> signals)
  {
    return new string(determineEight(signals).Except(determineNine(signals)).ToArray());
  }

  private static string determineC(List<string> signals)
  {
    return new string(determineEight(signals).Except(determineSix(signals)).ToArray());
  }

  private static string determineF(List<string> signals)
  {
    return new string(determineOne(signals).Except(determineC(signals)).ToArray());
  }

  private static string determineFive(List<string> signals)
  {
    var c = determineC(signals);
    var e = determineE(signals);
    var f = signals.FindByLength(5);
    var g = f.Where(a => !a.Contains(c) && !a.Contains(c));
    return new string(g.SingleOrderCharArray());
  }

  private static string determineTwo(List<string> signals)
  {
    var c = determineC(signals);
    var f = determineF(signals);
    var five = determineFive(signals);
    var x = signals.FindByLength(5);
    var g = x.Where(a => a != five && a.Contains(c) && !a.Contains(f));
    return new string(g.SingleOrderCharArray());
  }

  private static string determineThree(List<string> signals)
  {
    var five = determineFive(signals);
    var two = determineTwo(signals);
    var x = signals.FindByLength(5);
    var g = x.Where(a => a != five && a != two);
    return new string(g.SingleOrderCharArray());
  }

  // private static char determineC(List<string> signals)
  // {
  //   string One = signals.FindByLength(2).First();
  //   char[] Eight = signals.FindByLength(7).First().ToArray();

  //   var Sixes = signals.FindByLength(6);

  //   var c = Sixes.Where(x =>
  //   {
  //     char[] t = x.ToArray();
  //     if (One.Contains(Eight.Except(t).First())) return true;
  //     else return false;
  //   });

  //   return Eight.Except(c.First()).First();
  // }


}

public static class DigitExtensions
{

  public static IEnumerable<string> FindByLength(this IEnumerable<string> x, int length)
  {
    return x.Where(x => x.Length == length);
  }

  public static char[] SingleOrderCharArray(this IEnumerable<string> x)
  {
    return x.Single().ToCharArray().OrderBy(a => a).ToArray();
  }


}


