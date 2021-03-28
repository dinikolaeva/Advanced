using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse);

            var evenNumbers = input.Where(n => n % 2 == 0)
                                   .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
