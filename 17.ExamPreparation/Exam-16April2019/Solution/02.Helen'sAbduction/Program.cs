using System;
using System.Linq;

namespace _02.Helen_sAbduction
{
    class Program
    {
        private static bool IsHelenFound = false;
        private static int parisRow = 0;
        private static int parisCol = 0;
        private static char[][] matrix;
        private static int n;

        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());

            matrix = new char[n][];
            
            ReadMatrixAndFoundParis(n, matrix, ref parisRow, ref parisCol);

            while (energy > 0 && !IsHelenFound)
            {
                string[] command = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                var direction = command[0];
                var spownRow = int.Parse(command[1]);
                var spownCol = int.Parse(command[2]);

                matrix[spownRow][spownCol] = 'S';
                energy--;

                try
                {
                    MoveParis(ref energy, matrix, ref parisRow, ref parisCol, direction);
                }
                catch (IndexOutOfRangeException)
                {
                    matrix[parisRow][parisCol] = 'P';
                    continue;
                }
            }

            if (IsHelenFound == true)
            {
                matrix[parisRow][parisCol] = '-';
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                matrix[parisRow][parisCol] = 'X';
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MoveParis(ref int energy, char[][] matrix, ref int parisRow, ref int parisCol, string direction)
        {
            matrix[parisRow][parisCol] = '-';

            if (direction == "up")
            {
                IfIndexIsOutOfTheRange(parisRow - 1, parisCol);
                parisRow--;
            }
            else if (direction == "down")
            {
                IfIndexIsOutOfTheRange(parisRow + 1, parisCol);
                parisRow++;
            }
            else if (direction == "left")
            {
                IfIndexIsOutOfTheRange(parisRow, parisCol - 1);
                parisCol--;
            }
            else if (direction == "right")
            {
                IfIndexIsOutOfTheRange(parisRow, parisCol + 1);
                parisCol++;
            }

            if (matrix[parisRow][parisCol] == 'S')
            {
                energy -= 2;
            }
            else if (matrix[parisRow][parisCol] == 'H')
            {
                IsHelenFound = true;
            }

        }

        private static char IfIndexIsOutOfTheRange(int row, int col)
            => matrix[row][col];

        private static void ReadMatrixAndFoundParis(int n, char[][] matrix, ref int parisRow, ref int parisCol)
        {
            for (int row = 0; row < n; row++)
            {
                var lines = Console.ReadLine();

                matrix[row] = new char[lines.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (lines[col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }

                    matrix[row][col] = lines[col];
                }
            }
        }
    }
}
