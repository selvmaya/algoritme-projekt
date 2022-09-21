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

	public void Display()
	{
		// make box
		const char horizontalChar = '-';
		const char verticalChar = '|';
		const char cornerChar = 'X'; // displayed in the corners of the boxes draw with horizontal and vertical char

		string dealerInfo = Dealer.ToString();
		string[] playerInfos = Player.Info();
		int dealerContentWidth = dealerInfo.Length;
		int playerContentWidth = Math.Max(playerInfos[0].Length, playerInfos[1].Length);

		int absoluteBoxWidth = Math.Max(playerContentWidth, dealerContentWidth) + 2;

		string horizontalEdge = $"{cornerChar}{new string(horizontalChar, absoluteBoxWidth)}{cornerChar}";
		Console.WriteLine(horizontalEdge);

		string[][] contents =
		{
			new [] {
				"DEALER:",
				Dealer.ToString()
			},
			new []
			{
				"PLAYER:", playerInfos[0], playerInfos[1],
			}
		};
		foreach (string[] content in contents)
		{
			foreach (string line in content)
			{
				Console.Write($"{verticalChar} {line}"); // write left side of box + line
				Console.CursorLeft = absoluteBoxWidth + 1;
				Console.WriteLine(verticalChar); // write right side of box, go next line
			}
			Console.WriteLine(horizontalEdge);
		}
	}
}