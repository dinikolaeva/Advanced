using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            List<int> plates = new List<int>(Console.ReadLine().Split().Select(int.Parse));

            var stackWarriors = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                var warriors = Console.ReadLine().Split().Select(int.Parse);

                stackWarriors = new Stack<int>(warriors);

                if (i % 3 == 0)
                {
                    var extraPlates = int.Parse(Console.ReadLine());
                    plates.Add(extraPlates);
                }

                while (plates.Count != 0 && stackWarriors.Count != 0)
                {
                    int currentPlate = plates[0];
                    int currentWarrior = stackWarriors.Pop();

                    if (currentPlate == currentWarrior)
                    {
                        plates.RemoveAt(0);
                    }

                    if (currentPlate > currentWarrior)
                    {
                        currentPlate -= currentWarrior;
                        plates[0] = currentPlate;
                    }

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        plates.RemoveAt(0);
                        stackWarriors.Push(currentWarrior);
                    }                  
                }

                if (!plates.Any())
                {
                    break;
                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", stackWarriors)}");
            }
        }
    }
}
