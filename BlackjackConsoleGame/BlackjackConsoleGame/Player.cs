namespace BlackjackConsoleGame;

public class Player : Hand
{
	private int _activeBet;

	public int Points { get; private set; }

	private const int StartingPoints = 100;

	public Player()
	{
		Points = StartingPoints;
	}

	public override string[] Info()
	{
		return base.Info().Concat(new[]
		{
			$"Current points {Points}, Current bet: {_activeBet}",
		}).ToArray();
	}

	public bool CanBet(int minimum) => Points >= minimum;

	public void MakeBet(int amount)
	{
		_activeBet = Math.Min(amount, Points);
		Points -= _activeBet;
	}
	public void LoseBet()
	{
		_activeBet = 0;
	}
	public void RefundBet()
	{
		Points += _activeBet;
		_activeBet = 0;
	}
	public void WinBet()
	{
		Points += _activeBet * 2;
		_activeBet = 0;
	}
}