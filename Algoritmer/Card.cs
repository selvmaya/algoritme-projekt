namespace Algoritmer;

internal class Card
{
	public const int HighestCardNumber = 13;
	public const int DeckSize = 52;

	public readonly CardType Type;
	public readonly int Number;

	public Card(int number, CardType type)
	{
		Number = number;
		Type = type;
	}

	public string NumberName()
	{
		return Number switch
		{
			1 => "Ace",
			11 => "Jack",
			12 => "Queen",
			13 => "King",
			_ => Number.ToString(),
		};
	}

	public string FullName()
	{
		return $"{NumberName()} of {Type}";
	}

	public void Draw(Graphics graphics, Pen pen)
	{
		Rectangle rect = new Rectangle(); // todo: define card placement/size
		graphics.DrawRectangle(pen, rect);

		// todo: draw card number/name
	}
}