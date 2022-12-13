using System;
using System.Collections.Generic;

namespace Dmitriy_Vysotskyy.Tasks
{
	public static class Task1
	{
       public static List<object> GetIntegersFromList(List<object> inputList)
       {
            var outputList = new List<object>();

            foreach (var item in inputList)
                if (item.GetType() == typeof(System.Int32))
                    outputList.Add(item);

            return outputList;
       }
    }
}

