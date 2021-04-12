using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                                      .Split(new char[] { ' ' })
                                      .Select(int.Parse)
                                      .ToList();

            Stack<int> rowerOfOrcs = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                int[] currentOrcsWave = Console.ReadLine()
                                               .Split(new char[] { ' ' })
                                               .Select(int.Parse)
                                               .ToArray();

                for (int j = 0; j < currentOrcsWave.Length; j++)
                {
                    rowerOfOrcs.Push(currentOrcsWave[j]);
                }

                if (i % 3 == 0)
                {
                    int extraPalte = int.Parse(Console.ReadLine());

                    plates.Add(extraPalte);
                }

                while (plates.Any() && rowerOfOrcs.Any())
                {
                    int currentPlate = plates[0];
                    int currentOrc = rowerOfOrcs.Peek();

                    if (currentPlate == currentOrc)
                    {
                        plates.RemoveAt(0);
                        rowerOfOrcs.Pop();
                    }

                    if (currentPlate > currentOrc)
                    {
                        plates[0] -= currentOrc;
                        rowerOfOrcs.Pop();
                    }

                    if (currentOrc > currentPlate)
                    {
                        rowerOfOrcs.Push(rowerOfOrcs.Pop() - currentPlate);
                        plates.RemoveAt(0);
                    }
                }

                if (!plates.Any())
                {
                    break;
                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", rowerOfOrcs)}");
            }
        }
    }
}
