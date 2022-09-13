namespace Algoritmer;

internal class CardCollection
{
	public List<Card> Cards = new List<Card>();

	public void Shuffle()
	{
		for (int i = 0; i < Card.DeckSize; i++)
		{
			int randomIndex = Rand.Int(Card.DeckSize);
			// swap card index with random card index
			(Cards[i], Cards[randomIndex]) = (Cards[randomIndex], Cards[i]);
		}
	}
}