namespace BlackjackConsoleGame.Cards;

public class Hand : CardCollection
{
	private bool _dirty;
	private int _total;
	public int TotalSum
	{
		get
		{
			if (!_dirty) return _total;

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
				int contender = largestAllowedAceTotal + 10;
				if (contender + sum <= 21) largestAllowedAceTotal = contender;
				else break;
			}

			return _total = sum + largestAllowedAceTotal;
		}
	}

	public override string ToString()
	{
		return $"[Total = {TotalSum}], [Cards = ({string.Join(", ", Cards)})]";
	}

	public void ReceiveCard(Card card)
	{
		_dirty = true;
		Cards.Add(card);
	}
}