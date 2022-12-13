using System;
namespace Dmitriy_Vysotskyy.Tasks
{
	public static class Task4
	{
        public static int GetTargetPair(int[] array, int target)
        {
            int counter = 0;

            for (var i = 0; i < array.Length - 1; i++)
                for (var j = i + 1; j < array.Length; j++)
                    if ((array[i] + array[j]) == target)
                        counter++;

            return counter;
        }
    }
}

