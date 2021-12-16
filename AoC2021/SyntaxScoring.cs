using MathNet.Numerics.Statistics;

namespace AoC2021;

public class SyntaxScoring
{

  public static int CorruptLinesScore(List<string> inputLines)
  {
    int score = 0;

    inputLines.ForEach(x =>
    {
      char[] chars = x.ToCharArray();
      Stack<char> myStack = new Stack<char>();
      foreach (char c in chars)
      {
        if (c == '(') myStack.Push(c);
        if (c == '[') myStack.Push(c);
        if (c == '{') myStack.Push(c);
        if (c == '<') myStack.Push(c);
        if (c == ')')
        {
          char f = myStack.Peek();
          if (f == '(') myStack.Pop();
          else
          {
            score += 3;
            break;
          }

        }
        if (c == ']')
        {
          char f = myStack.Peek();
          if (f == '[') myStack.Pop();
          else
          {
            score += 57;
            break;
          }

        }
        if (c == '}')
        {
          char f = myStack.Peek();
          if (f == '{') myStack.Pop();
          else
          {
            score += 1197;
            break;
          }

        }
        if (c == '>')
        {
          char f = myStack.Peek();
          if (f == '<') myStack.Pop();
          else
          {
            score += 25137;
            break;
          }

        }

      }


    }
  );
    return score;
  }

  public static double IncompleteLinesScore(List<string> inputLines)
  {
    string openChars = "([{<";
    string closeChars = ")]}>";
    List<double> score = new();

    List<string> corruptedLines = new();

    inputLines.ForEach(x =>
    {
      char[] chars = x.ToCharArray();
      Stack<char> myStack = new Stack<char>();
      foreach (char c in chars)
      {
        if (openChars.IndexOf(c) >= 0)
        {
          myStack.Push(c);
        }
        else if (closeChars.IndexOf(c) >= 0)
        {
          if (myStack.Peek().Equals(openChars[closeChars.IndexOf(c)]))
          {
            myStack.Pop();
          }
          else
          {
            corruptedLines.Add(x);
            break;
          }
        }
      }
    });
    List<string> incompleteLines = inputLines.Except(corruptedLines).ToList();


    incompleteLines.ForEach(x =>
    {
      char[] chars = x.ToCharArray();
      Stack<char> myStack = new Stack<char>();
      foreach (char c in chars)
      {
        if (openChars.IndexOf(c) >= 0)
        {
          myStack.Push(c);
        }
        else if (closeChars.IndexOf(c) >= 0)
        {
          if (myStack.Peek().Equals(openChars[closeChars.IndexOf(c)]))
          {
            myStack.Pop();
          }
        }
      }
      score.Add(CaclulateStackScore(myStack));
    });

    return Statistics.Median(score);
  }

  private static double CaclulateStackScore(Stack<char> stack)
  {
    string openChars = "([{<";

    double score = 0;
    foreach (char c in stack)
    {
      score *= 5;
      score += openChars.IndexOf(c) + 1;
    }


    return score;

  }
}