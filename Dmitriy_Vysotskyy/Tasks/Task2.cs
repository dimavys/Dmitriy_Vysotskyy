using System;
namespace Dmitriy_Vysotskyy.Tasks
{
    public static class Task2
    {
        public static string GetFirstNonRepeatingLetter(string str)
        {
            bool uniqueStatus = false;
            var result = "None";
            for (var i = 0; i < str.Length; i++)
            {
                uniqueStatus = true;
                for (var j = 0; j < str.Length; j++)
                {
                    if (char.ToUpper(str[i]) == char.ToUpper(str[j]) && (i != j))
                    {
                        uniqueStatus = false;
                        break;
                    }
                }
                if (uniqueStatus)
                {
                    result = str[i].ToString();
                    break;
                }
            }
            return result;
        }
    }
}

