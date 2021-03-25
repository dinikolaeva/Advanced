using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int first = sizes[0];
            int second = sizes[1];

            var firstList = new List<int>();
            var secondList = new List<int>();
            var thirdSet = new HashSet<int>();

            for (int i = 0; i < first; i++)
            {
                firstList.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < second; i++)
            {
                secondList.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < firstList.Count; i++)
            {
                if (secondList.Contains(firstList[i]))
                {
                    thirdSet.Add(firstList[i]);
                }
            }
            for (int i = 0; i < secondList.Count; i++)
            {
                if (firstList.Contains(secondList[i]))
                {
                    thirdSet.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", thirdSet));
        }
    }
}
