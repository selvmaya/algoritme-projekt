namespace BlackjackConsoleGame.Cards;

public class Deck : CardCollection
{
	public Deck() // fresh deck of cards
	{
		Cards = FreshCards();
	}

	private static List<Card> FreshCards()
	{
		Array types = Enum.GetValues(typeof(CardType));
		int typeTotal = types.Length;

		List<Card> cards = new List<Card>();
		for (int numberIndex = 1; numberIndex <= Card.HighestCardNumber; numberIndex++)
		{
			for (int typeIndex = 0; typeIndex < typeTotal; typeIndex++)
			{
				CardType type = (CardType)types.GetValue(typeIndex)!;
				Card card = new Card(numberIndex, type);
				cards.Add(card);
			}
		}
		return cards;
	}

	public void GiveCardTo(Hand hand)
	{
		if (Cards.Count == 0) return;
		Card topCard = Cards[0];
		hand.ReceiveCard(topCard);
		Cards.RemoveAt(0);
	}

	public void GiveCardsTo(Hand hand, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GiveCardTo(hand);
		}
	}
}