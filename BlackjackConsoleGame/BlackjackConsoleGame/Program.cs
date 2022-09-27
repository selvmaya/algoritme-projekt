namespace BlackjackConsoleGame;

public static class Program
{
	public static void Main()
	{
		bool dealerIsDrawing;
		bool? lastAnswer;

		Table table = new Table(); // player should keep bet between games

        do // repeated games
        {
	        table.ResetAllCards();

	        // bools for runtime display options
	        lastAnswer = null;
	        dealerIsDrawing = false;

			void UpdateTableInfo() // TODO: make this prettier/graphically detailed
			{
				Console.Clear();
				Console.WriteLine("BLACKJACK: GET TO 21");
				InsertNewline();
				table.Display();
				InsertNewline();

				if (dealerIsDrawing) Console.WriteLine("Dealer is drawing cards...");
				else if (lastAnswer != null) Console.WriteLine($"You said {(lastAnswer.Value ? "yes" : "no")} to get a card.");
			}

			table.Deck.Shuffle();
			table.GiveStartingCards();
            UpdateTableInfo();

			// give cards to player untill they say no, OR total >= 21 (immediate win or loss)
            while (table.Player.TotalSum < 21 && BoolAsk("Do you want another card?"))
            {
	            table.Deck.GiveCardTo(table.Player);
	            UpdateTableInfo();
	            if (table.Player.TotalSum >= 21) break;

	            if (BoolAsk("Do you want to increase your bet?"))
	            {
		            const int minimum = 1;
		            if (table.Player.CanBet(minimum))
		            {
			            table.Player.MakeBet(BetAmount());
			            UpdateTableInfo();

			            int BetAmount()
			            {
				            int amount;
				            bool underMininum = false;
				            bool overPoints = false;
							do
							{
								if (underMininum) Console.WriteLine($"You cannot bet less than minium. ({minimum})");
								if (overPoints) Console.WriteLine($"You cannot bet more than you have. ({table.Player.Points})");

								amount = IntAsk("How much do you want to bet?");
								underMininum = amount < minimum;
								overPoints = amount > table.Player.Points;
							}
							while (underMininum || overPoints);
							return amount;
			            }
		            }
	            }
            }
            lastAnswer = null;

            if (table.Player.TotalSum < 21)
            {
				dealerIsDrawing = true;
				// give cards to dealer untill total >= 17
				while (table.Dealer.TotalSum < 17)
				{
					table.Deck.GiveCardTo(table.Dealer);

					// dramatically add cards
					UpdateTableInfo();
					Thread.Sleep(750);
				}
				dealerIsDrawing = false;
            }

			// dramatically let player see final cards before end condition is stated
			UpdateTableInfo();
			Thread.Sleep(1000);

			// game end
			EndCondition endCondition = CheckEndCondition();
			table.EndGame(endCondition);
			UpdateTableInfo();
			Console.WriteLine(SelectEndText(endCondition));

			EndCondition CheckEndCondition()
			{
				if (table.Player.TotalSum == table.Dealer.TotalSum)
					return EndCondition.Tie;
				if (table.Player.TotalSum > 21)
					return EndCondition.LossOver21;
				if (table.Player.TotalSum < table.Dealer.TotalSum)
					return EndCondition.LossUnderDealer;
				return EndCondition.Win;
			}
			static string SelectEndText(EndCondition endTerms)
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
        } while (BoolAsk("Do you want to play again?"));

        Console.Clear();
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey(); // program end

        bool BoolAsk(string question, char trueChar = 'Y', char falseChar = 'N')
        {
	        bool invalidAnswer = false;
	        do
	        {
		        Console.WriteLine(question);
		        if (invalidAnswer) Console.WriteLine($"Invalid answer. Write either '{trueChar}' or '{falseChar}'.");
				string? input = ReadUserInput()?.ToUpper();
				if (input == null) continue;
				bool answeredTrue = input.Contains(trueChar);
				bool answeredFalse = input.Contains(falseChar);
				invalidAnswer = !(answeredTrue || answeredFalse);
				if (!invalidAnswer)
				{
					if (answeredTrue) lastAnswer = true;
					else if (answeredFalse) lastAnswer = false;
				}
	        } while (invalidAnswer);
	        return lastAnswer != null && lastAnswer.Value;
		}
        int IntAsk(string amountQuestion)
        {
	        int amount;
	        bool inputInvalidString = false;
	        do
	        {
				Console.WriteLine(amountQuestion);
				if (inputInvalidString) Console.WriteLine("Invalid input.\nPlease try again.");
				string? input = ReadUserInput();
				inputInvalidString = int.TryParse(input, out amount);
	        } while (!inputInvalidString);
	        return amount;
        }
	}

	private static string? ReadUserInput()
	{
		Console.Write("> ");
		return Console.ReadLine();
	}

	private static void InsertNewline(int amount = 1)
	{
		Console.Write(new string('\n', amount));
	}
}