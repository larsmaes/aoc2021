using System.Collections.Generic;
using Xunit;

namespace AoC2021.Tests;

public class SyntaxScoringTests
{

  List<string> inputLines = new()
  {
    "[({(<(())[]>[[{[]{<()<>>",
    "[(()[<>])]({[<{<<[]>>(",
    "{([(<{}[<>[]}>{[]{[(<()>",
    "(((({<>}<{<{<>}{[]{[]{}",
    "[[<[([]))<([[{}[[()]]]",
    "[{[{({}]{}}([{[{{{}}([]",
    "{<[[]]>}<{[{[{[]{()[[[]",
    "[<(<(<(<{}))><([]([]()",
    "<{([([[(<>()){}]>(<<{{",
    "<{([{{}}[<[[[<>{}]]]>[]]"
  };

  [Fact]
  public void TestCorruptLinesScore()
  {
    Assert.Equal(26397, SyntaxScoring.CorruptLinesScore(inputLines));
  }

  [Fact]
  public void TestIncompleteLinesScore()
  {
    Assert.Equal(288957, SyntaxScoring.IncompleteLinesScore(inputLines));
  }


}