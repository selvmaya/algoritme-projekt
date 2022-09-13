namespace Algoritmer;

public static class RandTools
{
	public static int RandomRange(this Random random, int min, int max)
	{
		int range = max - min;
		double variance = range * random.NextDouble();
		return min + (int)variance;
	}
	public static float RandomRange(this Random random, float min, float max)
	{
		float range = max - min;
		double variance = range * random.NextDouble();
		return min + (float)variance;
	}
	public static double RandomRange(this Random random, double min, double max)
	{
		double range = max - min;
		double variance = range * random.NextDouble();
		return min + variance;
	}
}