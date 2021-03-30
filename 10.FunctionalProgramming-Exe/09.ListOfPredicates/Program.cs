using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                bool currentNumberIsDivided = true;

                foreach (var divideNumber in dividers)
                {
                    if (!(i % divideNumber == 0))
                    {
                        currentNumberIsDivided = false;
                        break;
                    }
                }
                if (currentNumberIsDivided)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}
