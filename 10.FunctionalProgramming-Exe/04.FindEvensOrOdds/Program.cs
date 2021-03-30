using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            string oddOrEven = Console.ReadLine();

            Predicate<int> odd = n => n % 2 != 0;
            Predicate<int> even = n => n % 2 == 0;
            List<int> filterNUmbers = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                if (oddOrEven == "odd")
                {
                    if (odd(i))
                    {
                        filterNUmbers.Add(i);
                    }
                }
                else
                {
                    if (even(i))
                    {
                        filterNUmbers.Add(i);
                    }
                }
            }

            Console.WriteLine(string.Join(' ', filterNUmbers));

        }
    }
}
