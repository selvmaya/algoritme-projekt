using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public static class Program
{
	public static void Main()
	{
		bool dealerIsDrawing;
		bool? lastAnswer;

        do // repeated games
        {
	        Table table = new Table();

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
				Console.WriteLine($"DEALER:\n{dealer}");
				InsertNewline();
				Console.WriteLine($"PLAYER:\n{player}");
				InsertNewline();
				if (dealerIsDrawing) Console.WriteLine("Dealer is drawing cards...");
				else if (lastAnswer != null) Console.WriteLine($"You said {(lastAnswer.Value ? "yes" : "no")} to get a card.");
			}

			table.Deck.Shuffle();
			table.GiveStartingCards();
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
			dealerIsDrawing = false;

			// dramatically let player see final cards before end condition is stated
			UpdateTableInfo();
			Thread.Sleep(1000);

			// game end
			EndCondition endCondition = CheckEndCondition();
			table.EndGame(endCondition);
			Console.WriteLine(SelectEndText(endCondition));

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
			lastAnswer = input?.ToUpper().Contains(requiredChar);
			return lastAnswer != null && lastAnswer.Value;
		}

        int IntAsk(string amountQuestion, int mininum = 0)
        {
	        int amount = 0;
	        int inputAttempts = 0;
	        bool validInput = false;
	        do
	        {
				Console.Write(amountQuestion);
				if (inputAttempts > 0) Console.WriteLine("Invalid input. Please try again.");

				string? input = Console.ReadLine();
				validInput = int.TryParse(input, out amount);
				inputAttempts++;
	        } while (!validInput);
	        return amount;
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