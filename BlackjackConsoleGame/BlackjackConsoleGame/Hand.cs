using BlackjackConsoleGame.Cards;

namespace BlackjackConsoleGame;

public class Hand : CardCollection
{
	private int _total;
	private bool _totalIsDirty;
	public int TotalSum
	{
		get
		{
			if (!_totalIsDirty) return _total;

			int sum = 0;
			int aces = 0;
			foreach (Card card in Cards)
			{
				if (card.Value == 1)
				{
					aces++; // we need to account for ace choice
					continue; // aces are added at the end
				}
				sum += card.Value;
			}
			int largestAllowedAceTotal = 1 * aces;
			for (int i = 0; i < aces; i++)
			{
				// chose the largest possible ace value that doesn't bust
				int contender = largestAllowedAceTotal + 10;
				if (contender + sum <= 21) largestAllowedAceTotal = contender;
				else break;
			}

			return _total = sum + largestAllowedAceTotal;
		}
	}

	public virtual string[] Info()
	{
		return new[]
		{
			$"Total: {TotalSum}",
			$"Card{(Cards.Count > 1 ? "s" : "")}: {string.Join(", ", Cards)}",
		};
	}

	public override string ToString()
	{
		return $"Total: {TotalSum}, Card{(Cards.Count > 1 ? "s" : "")}: {string.Join(", ", Cards)}";
	}

	public void ReceiveCard(Card card)
	{
		_totalIsDirty = true;
		Cards.Add(card);
	}
}