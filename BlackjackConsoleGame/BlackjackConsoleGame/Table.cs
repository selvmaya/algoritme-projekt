using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public class Table
{
	public readonly Deck Deck;
	public readonly Hand Dealer;
	public readonly Player Player; // might want to into a list/array

	public Table()
	{
		Deck = new Deck();
		Dealer = new Hand();
		Player = new Player();
	}

	public void GiveStartingCards()
	{
		Deck.GiveCardTo(Dealer);
		Deck.GiveCardsTo(Player, 2);
	}

	public void EndGame(EndCondition condition)
	{
		switch (condition)
		{
			case EndCondition.Win:
				Player.WinBet();
				break;
			case EndCondition.Tie:
				Player.RefundBet();
				break;
			case EndCondition.LossOver21:
			case EndCondition.LossUnderDealer:
				Player.LoseBet();
				break;
		}
	}
}