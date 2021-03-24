using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var storedInfoForContinents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!storedInfoForContinents.ContainsKey(continent))
                {
                    storedInfoForContinents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!storedInfoForContinents[continent].ContainsKey(country))
                {
                    storedInfoForContinents[continent].Add(country, new List<string>());
                }
                storedInfoForContinents[continent][country].Add(city);
            }

            foreach (var continent in storedInfoForContinents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
