using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public static class Program
{
	public static void Main()
    {
        Console.WriteLine("APP START");
        Thread.Sleep(500);
        do // repeated games
        {
            Hand dealer = new Hand();
            Hand player = new Hand();
	        Deck deck = new Deck();

			void UpdateTableInfo() // TODO: make this prettier/graphically detailed
			{
				Console.Clear();
				Console.WriteLine("--- BLACKJACK: GET TO 21 ---");
				Newline();
				Console.WriteLine($"DEALER: {dealer}");
				Console.WriteLine($"PLAYER: {player}");
				Newline();
			}

            deck.Shuffle();
            deck.GiveCardTo(dealer); // dealer starts with 1 card.
            deck.GiveCardsTo(player, 2); // player gets 2 cards.
            UpdateTableInfo();

			// give cards untill player says no OR total >= 21
            while (player.TotalSum < 21 && BoolAsk("Do you want another card?"))
            {
	            deck.GiveCardTo(player);
	            UpdateTableInfo();
            }

			// game end
			deck.GiveCardTo(dealer);
			UpdateTableInfo();
			if (player.TotalSum == dealer.TotalSum) // tie
            {
	            Console.WriteLine("TIE WITH DEALER.");
            }
            else if (player.TotalSum > 21 || player.TotalSum < dealer.TotalSum) // lose
            {
	            Console.WriteLine("LOSE. Larger than 21 OR less than dealer.");
            }
            else // win
            {
	            Console.WriteLine("WIN.");
            }

            Newline(3);
        } while (BoolAsk("Do you want to play again?"));

        Console.Clear();
        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
    }

	private static void Newline(int amount = 1)
    {
        Console.Write(new string('\n', amount));
    }
    private static bool BoolAsk(string question, char requiredChar = 'Y')
    {
	    Console.WriteLine(question);
	    string? input = Console.ReadLine();
	    return input != null && input.ToUpper().Contains(requiredChar);
    }
}