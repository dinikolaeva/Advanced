using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var even = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            var odd = numbers.Where(y => y % 2 != 0).OrderBy(y => y).ToList();

            even.AddRange(odd);

            Console.WriteLine(string.Join(' ', even));
        }
    }
}
