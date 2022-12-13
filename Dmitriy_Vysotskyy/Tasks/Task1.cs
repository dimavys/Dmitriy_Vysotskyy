using System;
using System.Collections.Generic;

namespace Dmitriy_Vysotskyy.Tasks
{
	public static class Task1
	{
       public static List<object> GetIntegersFromList(List<object> inputList)
       {
            foreach (var item in inputList)
                if (item.GetType() != typeof(System.Int32))
                    inputList.Remove(item);

            return inputList;
       }
    }
}

