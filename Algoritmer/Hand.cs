namespace Algoritmer;

internal class Hand : CardCollection
{
	public void ReceiveCard(Card card)
	{
		Cards.Add(card);
	}
}