namespace AoC2021;
public class Sonar
{

  /// <summary>This will output the number of depth increases found in the list of sweeped depths</summary>
  /// <param name="depths">List of integers that contain the depths that are sweeped by the Sonar</param>
  public static int depthIncreaseReport(List<int> depths)
  {
    int increase = 0;
    int previousDepth = 0;
    foreach (int depth in depths)
    {
      if (previousDepth != 0)
      {
        if (depth > previousDepth)
        {
          increase++;
        }
      }
      previousDepth = depth;
    }
    return increase;
  }

  
  /// <summary>This will output the number of depth increases found in the list of sweeped depths, where the calculation
  /// is based on a sliding window</summary>
  /// <param name="depths">List of integers that contain the depths that are sweeped by the Sonar</param>
  /// <param name="window">Numbers of depths to be considered in a window</param>
  public static int depthIncreaseSlidingWindowReport(List<int> depths, int window)
  {

    var tempDepths = new List<int>();
    for (int offset = 0; offset <= depths.Count() - window; offset++)
    {
      var windowsDepths = depths.GetRange(offset, window);
      tempDepths.Add(windowsDepths.Sum());
    }
    return depthIncreaseReport(tempDepths);
  }
}
