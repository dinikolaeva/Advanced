using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            int[,] garden = new int[input[0], input[1]];

            var information = Console.ReadLine();

            while (information != "Bloom Bloom Plow")
            {
                var coordinates = information.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (row < 0 || row >= garden.GetLength(0) ||
                    col < 0 || col >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int i = 0; i < garden.GetLength(0); i++)
                    {
                        for (int j = 0; j < garden.GetLength(1); j++)
                        {
                            if (i == row || j == col)
                            {
                                garden[i, j] += 1;
                            }
                        }
                    }
                }

                information = Console.ReadLine();
            }

            for (int rows = 0; rows < garden.GetLength(0); rows++)
            {
                for (int cols = 0; cols < garden.GetLength(1); cols++)
                {
                    Console.Write(garden[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
