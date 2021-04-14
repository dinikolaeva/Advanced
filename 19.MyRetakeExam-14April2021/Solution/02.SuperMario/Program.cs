using System;
using System.Linq;

namespace _02.Task
{
    class Program
    {
        private static bool ISPrincessPeachFound = false;
        private static int marioRow = 0;
        private static int marioCol = 0;
        private static char[][] matrix;
        private static int n;

        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            ReadMatrixAndFoundMario(n, matrix, ref marioRow, ref marioCol);

            while (lives > 0 && !ISPrincessPeachFound)
            {
                string[] command = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();

                var direction = command[0];
                var bowserRow = int.Parse(command[1]);
                var bowserCol = int.Parse(command[2]);

                matrix[bowserRow][bowserCol] = 'B';
                lives--;

                try
                {
                    MoveMario(ref lives, matrix, ref marioRow, ref marioCol, direction);
                }
                catch (IndexOutOfRangeException)
                {
                    matrix[marioRow][marioCol] = 'M';
                    continue;
                }
            }

            if (ISPrincessPeachFound == true)
            {
                matrix[marioRow][marioCol] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                matrix[marioRow][marioCol] = 'X';
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MoveMario(ref int lives, char[][] matrix, ref int marioRow, ref int marioCol, string direction)
        {
            matrix[marioRow][marioCol] = '-';

            if (direction == "W")
            {
                IfIndexIsOutOfTheRange(marioRow - 1, marioCol);
                marioRow--;
            }
            else if (direction == "S")
            {
                IfIndexIsOutOfTheRange(marioRow + 1, marioCol);
                marioRow++;
            }
            else if (direction == "A")
            {
                IfIndexIsOutOfTheRange(marioRow, marioCol - 1);
                marioCol--;
            }
            else if (direction == "D")
            {
                IfIndexIsOutOfTheRange(marioRow, marioCol + 1);
                marioCol++;
            }

            if (matrix[marioRow][marioCol] == 'B')
            {
                lives -= 2;
            }
            else if (matrix[marioRow][marioCol] == 'P')
            {
                ISPrincessPeachFound = true;
            }

        }

        private static char IfIndexIsOutOfTheRange(int row, int col)
            => matrix[row][col];

        private static void ReadMatrixAndFoundMario(int n, char[][] matrix, ref int marioRow, ref int marioCol)
        {
            for (int row = 0; row < n; row++)
            {
                var lines = Console.ReadLine();

                matrix[row] = new char[lines.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (lines[col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }

                    matrix[row][col] = lines[col];
                }
            }
        }
    }
}
