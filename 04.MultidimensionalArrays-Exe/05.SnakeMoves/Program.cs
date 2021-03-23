using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            char[] lengthOfTheSnake = Console.ReadLine().ToCharArray();

            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            char[,] matrix = new char[rows, cols];
            int placeToContinue = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = lengthOfTheSnake[placeToContinue];
                        placeToContinue++;
                        placeToContinue = GetIndex(lengthOfTheSnake, placeToContinue);
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = lengthOfTheSnake[placeToContinue];
                        placeToContinue++;
                        placeToContinue = GetIndex(lengthOfTheSnake, placeToContinue);
                    }
                }
            }

            PrintMatrix(matrix);


        }

        private static int GetIndex(char[] lengthOfTheSnake, int placeToContinue)
        {
            if (placeToContinue >= lengthOfTheSnake.Length)
            {
                placeToContinue = 0;
                return placeToContinue;
            }
            else
            {
                return placeToContinue;
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
