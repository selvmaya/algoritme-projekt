namespace Algoritmer;

public static class Rand
{
	public static readonly Random Random = new Random();

	public static int Int(int max = int.MaxValue)
	{
		return Random.Next(max);
	}

	public static int RandomRange(int min, int max)
	{
		int range = max - min;
		double variance = range * Random.NextDouble();
		return min + (int)variance;
	}
	public static float RandomRange(float min, float max)
	{
		float range = max - min;
		double variance = range * Random.NextDouble();
		return min + (float)variance;
	}
	public static double RandomRange(double min, double max)
	{
		double range = max - min;
		double variance = range * Random.NextDouble();
		return min + variance;
	}
}