using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

            var input = Console.ReadLine();

            Func<List<int>, string, List<int>> manipulator = (numbers, input) =>
            {
                if (input == "add")
                {
                    return numbers.Select(n => n + 1).ToList();
                }
                else if (input == "multiply")
                {
                    return numbers.Select(n => n * 2).ToList();
                }
                else
                {
                    return numbers.Select(n => n - 1).ToList();
                }
            };

            while (input != "end")
            {
                if (input == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }
                else
                {
                    numbers = manipulator(numbers, input);
                }
                input = Console.ReadLine();
            }
        }
    }
}
