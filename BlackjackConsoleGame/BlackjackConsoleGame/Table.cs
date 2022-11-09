using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public class Table
{
	public readonly Deck Deck;
	public readonly Hand Dealer;
	public readonly Player Player;

	public Table()
	{
		Deck = new Deck();
		Dealer = new Hand();
		Player = new Player();
	}

	public void ResetAllCards()
	{
		Deck.Reset();
		Dealer.ResetCards();
		Player.ResetCards();
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

	public void Display()
	{
		// make box
		const char horizontalChar = '-';
		const char verticalChar = '|';
		const char cornerChar = 'X'; // displayed in the corners of the boxes draw with horizontal and vertical char

		List<string> dealerInfos = Dealer.Info().ToList();
		dealerInfos.Insert(0, "DEALER:");
		List<string> playerInfos = Player.Info().ToList();
		playerInfos.Insert(0, "PLAYER:");

		List<string>[] contents = { dealerInfos, playerInfos };
		int absoluteBoxWidth = LongestLength(contents) + 2;

		string horizontalEdge = $"{cornerChar}{new string(horizontalChar, absoluteBoxWidth)}{cornerChar}";
		Console.WriteLine(horizontalEdge);

		foreach (List<string> content in contents)
		{
			foreach (string line in content)
			{
				Console.Write($"{verticalChar} {line}"); // write left side of box + line
				Console.CursorLeft = absoluteBoxWidth + 1;
				Console.WriteLine(verticalChar); // write right side of box, go next line
			}
			Console.WriteLine(horizontalEdge);
		}

		static int LongestLength(List<string>[] contents)
		{
			return (from content in contents from line in content select line.Length).Prepend(0).Max();
		}
	}
}