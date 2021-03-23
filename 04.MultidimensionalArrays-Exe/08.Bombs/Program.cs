using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            ReadMatrix(matrix);

            string[] coordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < coordinates.Length; i++)
            {
                var currentBomb = coordinates[i]
                     .Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

                int bombRow = currentBomb[0];
                int bombCol = currentBomb[1];
                int valueOfBomb = matrix[bombRow, bombCol];

                if (matrix[bombRow, bombCol] <= 0)
                {
                    continue;
                }
                else
                {
                    BombOperations(n, matrix, bombRow, bombCol, valueOfBomb);
                }

                matrix[bombRow, bombCol] = 0;
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BombOperations(int n, int[,] matrix, int bombRow, int bombCol, int valueOfBomb)
        {
            if (IsValid(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
            {
                matrix[bombRow - 1, bombCol] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0)
            {
                matrix[bombRow + 1, bombCol] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
            {
                matrix[bombRow, bombCol - 1] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
            {
                matrix[bombRow, bombCol + 1] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
            {
                matrix[bombRow - 1, bombCol - 1] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0)
            {
                matrix[bombRow - 1, bombCol + 1] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0)
            {
                matrix[bombRow + 1, bombCol - 1] -= valueOfBomb;
            }

            if (IsValid(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0)
            {
                matrix[bombRow + 1, bombCol + 1] -= valueOfBomb;
            }
        }

        private static bool IsValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static int[,] ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            return matrix;
        }
    }
}
