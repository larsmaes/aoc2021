namespace AoC2021;
public class Sonar
{

  /**
  * <summary>This will output the number of depth increases found in the list of sweeped depths</summary>
  * <paramn name="depths">List of integers that contain the depths that are sweeped by the Sonar</param>
  */
  public int depthIncreaseReport(List<int> depths) {
    int increase = 0;
    int previousDepth = 0;
    foreach (int depth in depths) {
      if (previousDepth == 0) {
        previousDepth = depth;
      }
      if (depth > previousDepth) {
        increase++;
      }
      previousDepth = depth;
    }
    return increase;
  }
}
