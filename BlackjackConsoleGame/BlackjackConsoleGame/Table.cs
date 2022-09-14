using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public class Table
{
	public readonly Deck Deck;
	public readonly Hand Dealer;
	public readonly Hand Player;

	public Table()
	{
		Deck = new Deck();
		Dealer = new Hand();
		Player = new Hand();
	}

	public void GiveStartingCards()
	{
		Deck.GiveCardTo(Dealer);
		Deck.GiveCardsTo(Player, 2);
	}
}