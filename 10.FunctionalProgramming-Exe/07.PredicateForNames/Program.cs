using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Where(x => x.Length <= n)
                               .ToArray();

            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}
