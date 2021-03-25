using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var chemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray();

                for (int j = 0; j < elements.Length; j++)
                {
                    string currentElement = elements[j];
                    chemicalElements.Add(currentElement);
                }
            }

            foreach (var element in chemicalElements)
            {
                Console.Write(element + ' '); ;
            }
        }
    }
}
