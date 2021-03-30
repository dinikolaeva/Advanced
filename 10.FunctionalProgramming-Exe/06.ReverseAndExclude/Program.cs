using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> isNotDivisible = x => x % n != 0;

            List<int> notDivisible = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (isNotDivisible(numbers[i]))
                {
                    notDivisible.Add(numbers[i]);
                }
            }

            notDivisible.Reverse();
            Console.WriteLine(string.Join(' ', notDivisible));
        }
    }
}
