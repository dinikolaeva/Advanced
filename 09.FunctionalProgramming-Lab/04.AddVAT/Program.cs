using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(double.Parse)
                               .Select(num => num * 1.20)
                               .ToArray();

            foreach (var price in input)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
