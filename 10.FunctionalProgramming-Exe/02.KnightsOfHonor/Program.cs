using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Action<string> knights = GetPrintTheSir(names);

            foreach (var knight in names)
            {
                knights(knight);
            }
        }

        private static Action<string> GetPrintTheSir(string[] names)
        {
            return name => Console.WriteLine($"Sir {name}"); ;
        }
    }
}
