namespace Algoritmer;

public static class Sorter
{
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
					int temp = myList[j];
					myList[j] = myList[j + 1];
					myList[j + 1] = temp;
				}
			}
		}

		return myList;
	}


}