using System.Diagnostics.CodeAnalysis;

namespace Algoritmer;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class Sorter
{
	// rasmus
	public static int[] MySort(int[] myList)
	{
		//Repeats the motion as many times as the list is long
		for (int i = 0; i < myList.Length; i++)
		{
			//Checks every index once until the end of the list is reached
			for (int j = 0; j < myList.Length; j++)
			{
				//Stop running this loop if the current index is the last
				if (j == myList.Length - 1) break;


				//If the next index has a higher value
				if (myList[j] > myList[j + 1])
				{
					//Swap the indexes
					(myList[j], myList[j + 1]) = (myList[j + 1], myList[j]);
				}
			}
		}

		return myList;
	}

	// mikkel
	private static void SortCustom(ref int[] numbers)
	{
		// left to right
		for (int i = 0; i < numbers.Length; i++)
		{
			// start point (right-ish (from zero)) towards left
			for (int j = i; j > 0; j--) // does not include zero index
			{
				int value = numbers[j];
				int valueOnLeft = numbers[j - 1];
				if (value >= valueOnLeft) continue;

				// swap values
				numbers[j - 1] = value;
				numbers[j] = valueOnLeft;
			}
		}
	}
}