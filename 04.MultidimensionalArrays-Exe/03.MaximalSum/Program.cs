using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();

            int maxSum = int.MinValue;
            int maxRowIndex = -1;
            int maxColIndex = -1;

            int submatrixRows = 3;
            int submatrixCols = 3;

            for (int row = 0; row < matrix.GetLength(0) - submatrixRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - submatrixCols + 1; col++)
                {
                    int sum = 0;

                    for (int subRow = 0; subRow < submatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < submatrixCols; subCol++)
                        {
                            sum += matrix[row + subRow, col + subCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < submatrixRows; row++)
            {
                for (int col = 0; col < submatrixCols; col++)
                {
                    Console.Write(matrix[maxRowIndex + row, maxColIndex + col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix()
        {
            int[] n = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

            int rows = n[0];
            int cols = n[1];

            int[,] matrix = new int[rows, cols];

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
