using System;
using System.Collections.Generic;
using System.Linq;

namespace Dmitriy_Vysotskyy.Tasks
{
    class Person
    {
        public string Name;

        public string Surname;

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }

    public class Task5
	{
        public static string GetSortedString(string str)
        {
            string name = "";
            string surname = "";
            bool nameToSurnameSwitcher = false;

            var personList = new List<Person>();

            for (var i = 0; i < str.Length; i++)
            {
                if (!nameToSurnameSwitcher)
                {
                    if (str[i] != ':')
                        name += char.ToUpper(str[i]);
                    else
                    {
                        nameToSurnameSwitcher = true;
                        i++;
                    }
                }
                if (nameToSurnameSwitcher)
                {
                    if (str[i] != ';')
                        surname += char.ToUpper(str[i]);
                    else
                    {
                        personList.Add(new Person(name, surname));
                        name = "";
                        surname = "";
                        nameToSurnameSwitcher = false;
                    }
                }
            }

            string result = "";

            foreach (var p in personList.OrderBy(p => p.Surname).ThenBy(p => p.Name))
                result += (p.Surname, p.Name);

            return result;
        }
    }
}

