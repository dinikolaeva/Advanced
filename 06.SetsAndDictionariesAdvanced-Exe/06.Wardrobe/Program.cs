using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] inputClothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < inputClothes.Length; j++)
                {
                    string currentClothes = inputClothes[j];

                    if (!wardrobe[color].ContainsKey(currentClothes))
                    {
                        wardrobe[color].Add(currentClothes, 0);
                    }
                    wardrobe[color][currentClothes]++;
                }
            }

            string[] wantedClothes = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();

            string wantedColor = wantedClothes[0];
            string wantedPieceOfClothing = wantedClothes[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var currentClothing in wardrobe[color.Key])
                {
                    if (color.Key == wantedColor && currentClothing.Key == wantedPieceOfClothing)
                    {
                        Console.WriteLine($"* {currentClothing.Key} - {currentClothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currentClothing.Key} - {currentClothing.Value}");
                    }
                }
            }
        }
    }
}
