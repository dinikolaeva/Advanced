using System;
using System.Linq;
using System.Collections.Generic;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .ToList();

            List<string> filterdNames = new List<string>();

            Func<string, int, bool> filter = (name, targetSum) =>
            {
                int sum = 0;

                foreach (var ch in name)
                {
                    sum += ch;
                }

                if (sum >= targetSum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            Func<Func<string, int, bool>, List<string>, int, string> printer = (filter, names, targetSum) =>
            {
                string currentName = string.Empty;

                foreach (var name in names)
                {
                    if (filter(name, targetSum))
                    {
                        currentName = name;
                        return currentName;
                    }
                }
                return currentName;
            };

            Console.WriteLine(printer(filter, names, targetSum));

        }
    }
}
