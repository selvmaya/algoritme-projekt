using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public static class Program
{
	private enum EndCondition
	{
		Tie,
		LossUnderDealer,
		LossOver21,
		Win,
	}

	public static void Main()
	{
		bool dealerIsDrawing;
		bool? lastAnswer;

        // Console.WriteLine("APP START");
        // Thread.Sleep(500);
        do // repeated games
        {
	        Table table = new Table();

	        // Deck deck = table.Deck;
            Hand dealer = table.Dealer;
            Hand player = table.Player;

	        // bools for runtime display options
	        lastAnswer = null;
	        dealerIsDrawing = false;

			void UpdateTableInfo() // TODO: make this prettier/graphically detailed
			{
				Console.Clear();
				Console.WriteLine("--- BLACKJACK: GET TO 21 ---");
				InsertNewline();
				Console.WriteLine($"DEALER: {dealer}");
				Console.WriteLine($"PLAYER: {player}");
				InsertNewline();
				if (dealerIsDrawing) Console.WriteLine("Dealer is drawing cards...");
				else if (lastAnswer != null) Console.WriteLine($"You said {(lastAnswer.Value ? "yes" : "no")} to get a card.");
			}

			table.Deck.Shuffle();
			table.Deck.GiveCardTo(dealer); // dealer starts with 1 card.
            table.Deck.GiveCardsTo(player, 2); // player gets 2 cards.
            UpdateTableInfo();

			// give cards to player untill they say no, OR total >= 21 (immediate win or loss)
            while (player.TotalSum < 21 && BoolAsk("Do you want another card?"))
            {
	            table.Deck.GiveCardTo(player);
	            UpdateTableInfo();
            }
            lastAnswer = null;

	        dealerIsDrawing = true;
            // give cards to dealer untill total >= 17
			while (dealer.TotalSum < 17)
			{
				table.Deck.GiveCardTo(dealer);

				// dramatically add cards
				UpdateTableInfo();
				Thread.Sleep(750);
			}

			// dramatically let player see final cards before end condition is stated
			dealerIsDrawing = false;
			UpdateTableInfo();
			Thread.Sleep(1000);

			// game end
			Console.WriteLine(SelectEndText(CheckEndCondition()));

			EndCondition CheckEndCondition()
			{
				if (player.TotalSum == dealer.TotalSum)
					return EndCondition.Tie;
				if (player.TotalSum > 21)
					return EndCondition.LossOver21;
				if (player.TotalSum < dealer.TotalSum)
					return EndCondition.LossUnderDealer;
				return EndCondition.Win;
			}
        } while (BoolAsk("Do you want to play again?"));

        Console.Clear();
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey(); // program end

        bool BoolAsk(string question, char requiredChar = 'Y')
		{
			Console.WriteLine(question);
			string? input = Console.ReadLine();
			lastAnswer = input != null && input.ToUpper().Contains(requiredChar);
			return lastAnswer.Value;
		}
	}

	private static void InsertNewline(int amount = 1)
	{
		Console.Write(new string('\n', amount));
	}
	private static string SelectEndText(EndCondition endTerms)
	{
		return endTerms switch
		{
			EndCondition.Tie => "TIE WITH DEALER.",
			EndCondition.LossOver21 => "YOU LOSE. You went over 21.",
			EndCondition.LossUnderDealer => "YOU LOSE. Your cards were less than the dealer's cards.",
			EndCondition.Win => "YOU WIN.",
			_ => "Invalid end condition?"
		};
	}
}