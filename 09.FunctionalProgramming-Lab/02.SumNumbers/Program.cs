using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse);

            
            Console.WriteLine($"{input.Count()}");
            Console.WriteLine($"{input.Sum()}");
        }
    }
}
