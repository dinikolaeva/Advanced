using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{  
    static class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                                   .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var age = int.Parse(input[1]);
                people.Add(name, age);
            }

            var condition = Console.ReadLine();
            var filterAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> currentPerson = Person(condition, filterAge);
            Action<KeyValuePair<string, int>> printer = GetPrint(format);
            PrintResult(people, currentPerson, printer);
        }

        private static void PrintResult(Dictionary<string, int> people, Func<int, bool> currentPerson, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (currentPerson(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> GetPrint(string format)
        {
            if (format == "name")
            {
                return person => Console.WriteLine($"{person.Key}");
            }
            else if (format == "age")
            {
                return person => Console.WriteLine($"{person.Value}");
            }
            else
            {
                return person => Console.WriteLine($"{person.Key} - {person.Value}");
            }
        }

        private static Func<int, bool> Person(string condition, int age)
        {
            if (condition == "older")
            {
                return p => p >= age;
            }
            else
            {
                return p => p < age;
            }
        }
    }
}
