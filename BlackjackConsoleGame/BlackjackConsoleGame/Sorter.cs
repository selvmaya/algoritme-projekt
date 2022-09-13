using System.Diagnostics.CodeAnalysis;

namespace BlackjackConsoleGame;

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
	// rasmus 2: binarySearch via recursion (calls itself using self-edited parameters)
	public static int BinarySearch(int[] sortedArray, int target, int startIndex, int endIndex)
	{
		//Stops crashes in wacky situations
		if (startIndex > endIndex) return 0;

		//Check if your value is on the middle index
		int mid = (startIndex + endIndex) / 2;
		if (target == sortedArray[mid]) return mid; //Here's your result

		//If my target is smaller than the middle index's value, run it again but only the first half
		if (target < sortedArray[mid]) return BinarySearch(sortedArray, target, startIndex, mid);

		//Otherwise run it again but only the second half
		return BinarySearch(sortedArray, target, mid, endIndex);
	}

	// mikkel
	public static void SortCustom(ref int[] numbers)
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