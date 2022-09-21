namespace BlackjackConsoleGame.Cards;

public class Card
{
	public const int HighestCardNumber = 13;
	public const int DeckSize = 52;

	private readonly CardType _type;
	private readonly int _number;
	private int _value;
	private bool _isDirty;
	public int Value
	{
		get
		{
			if (!_isDirty) return _value;
			_isDirty = false;
			return _value = _number >= 10 ? 10 : _number; // if 10 or larger, return 10
		}
	}

	public override string ToString()
	{
		return $"[{FullName()}]";
	}

	public Card(int number, CardType type)
	{
		_number = number;
		_type = type;
		_isDirty = true;
	}

	public string NameFromNumber()
	{
		return _number switch
		{
			1 => "Ace",
			11 => "Jack",
			12 => "Queen",
			13 => "King",
			_ => _number.ToString(),
		};
	}
	public string FullName()
	{
		return $"{NameFromNumber()} of {_type}";
	}
}