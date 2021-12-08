using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;

namespace AoC2021;


public class CrabSubMarine
{


  public static int CalculateLeastFuel(int[] crabs)
  {

    Dictionary<int,int> neededFuel = new(crabs.Max());

    foreach (var position in Enumerable.Range(crabs.Min(), crabs.Max()))
    {
      neededFuel.Add(position, 0);
      for (int i = 0; i < crabs.Length; i++)
      {
        neededFuel[position] += Math.Abs(crabs[i] - position);
      }
    }

    var ordered = from nf in neededFuel
                  orderby nf.Value
                  select nf;


    return ordered.First().Value;



  }

  public static int CalculateLeastFuelAccordingToCrabs(int[] crabs)
  {

    Dictionary<int,int> neededFuel = new(crabs.Max());

    foreach (var position in Enumerable.Range(crabs.Min(), crabs.Max()))
    {
      neededFuel.Add(position, 0);
      for (int i = 0; i < crabs.Length; i++)
      {
        var poffset = Math.Abs(crabs[i] - position);
        neededFuel[position] += (poffset*( poffset + 1 ))/2;
      }
    }

    var ordered = from nf in neededFuel
                  orderby nf.Value
                  select nf;


    return ordered.First().Value;



  }
}