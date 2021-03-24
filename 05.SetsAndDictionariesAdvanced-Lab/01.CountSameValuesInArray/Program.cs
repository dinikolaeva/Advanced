using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] n = Console.ReadLine()
                                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();

            var counter = new Dictionary<double, int>();

            for (int i = 0; i < n.Length; i++)
            {
                if (!counter.ContainsKey(n[i]))
                {
                    counter.Add(n[i], 0);
                }
                counter[n[i]]++;
            }

            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
