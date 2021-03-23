using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();

            var sumOfPrimaryDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumOfPrimaryDiagonal += matrix[row, col];
                        break;
                    }
                }
            }

            var sumOfSecondDiagonal = 0;
            int cols = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                sumOfSecondDiagonal += matrix[row, cols];
                cols++;
            }

            Console.WriteLine($"{Math.Abs(sumOfPrimaryDiagonal - sumOfSecondDiagonal)}");
        }

        private static int[,] ReadMatrix()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elementsCol = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elementsCol[col];
                }
            }

            return matrix;
        }
    }
}
