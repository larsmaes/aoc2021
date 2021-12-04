namespace AoC2021.Bingo;

public class Game
{

  private List<Card> BingoCards;

  public Game(List<Card> cards)
  {
    this.BingoCards = cards;
  }

  public int? PlayTillFirstWin(int[] numbers)
  {
    foreach (int i in numbers)
    {
      foreach (Card card in BingoCards)
      {
        card.MarkNumber(i);
        if (card.Won)
        {
          return card.sumOfUnMarkedNumbers() * i;
        }
      }
    }
    return null;
  }

  public int? PlayTillLastWin(int[] numbers)
  {
    int NumberOfCards = BingoCards.Count;
    int wonCards = 0;
    foreach (int i in numbers)
    {
      foreach (Card card in BingoCards)
      {
        if (!card.Won)
        {
          card.MarkNumber(i);
          if (card.Won)
          {
            wonCards++;
            if (wonCards == NumberOfCards)
            {
              return card.sumOfUnMarkedNumbers() * i;
            }
          }
        }
      }
    }
    return null;
  }




}