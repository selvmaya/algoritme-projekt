namespace Algoritmer;

internal class Deck : CardCollection
{
	public Deck() // fresh deck of cards
	{
		Cards = FreshCards();
	}

	private static List<Card> FreshCards()
	{
		List<Card> cards = new List<Card>();
		for (int numberIndex = 0; numberIndex < Card.HighestCardNumber; numberIndex++)
		{
			Array types = Enum.GetValues(typeof(CardType));
			int typeTotal = types.Length;
			for (int typeIndex = 0; typeIndex < typeTotal; typeIndex++)
			{
				CardType type = (CardType)types.GetValue(typeIndex)!;
				Card card = new Card(numberIndex, type);
				cards.Add(card);
			}
		}
		return cards;
	}

	public void GiveCardToHand(Hand hand)
	{
		if (Cards.Count == 0) return;
		Card topCard = Cards[0];
		hand.ReceiveCard(topCard);
		Cards.RemoveAt(0);
	}

	public void Draw(Graphics graphics, Pen pen)
	{
		// todo: define deck drawing area (placement/size)

		foreach (Card card in Cards)
		{
			card.Draw(graphics, pen);
		}
	}
}