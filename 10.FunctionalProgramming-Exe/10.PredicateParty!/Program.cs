using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                var command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                string action = command[0];
                string criteria = command[1];
                string substring = command[2];

                ActionsWithList(people, action, criteria, substring);

                input = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write($"{string.Join(", ", people)} are going to the party!");
            }
        }

        private static void ActionsWithList(List<string> people, string action, string criteria, string substring)
        {
            switch (action)
            {
                case "Remove":
                    if (criteria == "StartsWith")
                    {
                        people.RemoveAll(x => x.StartsWith(substring));
                    }
                    else if (criteria == "EndsWith")
                    {
                        people.RemoveAll(x => x.EndsWith(substring));
                    }
                    else if (criteria == "Length")
                    {
                        int length = int.Parse(substring);
                        people.RemoveAll(x => x.Length == length);
                    }
                    break;
                case "Double":
                    if (criteria == "StartsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].StartsWith(substring))
                            {
                                people.Insert(i, people[i]);
                            }
                            i++;
                        }
                    }
                    else if (criteria == "EndsWith")
                    {
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].EndsWith(substring))
                            {
                                people.Insert(i, people[i]);
                            }
                            i++;
                        }
                    }
                    else if (criteria == "Length")
                    {
                        int length = int.Parse(substring);

                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].Length == length)
                            {
                                people.Insert(i, people[i]);
                            }
                            i++;
                        }
                    }
                    break;
            }
        }
    }
}
