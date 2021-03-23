using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            double[][] jaggetArr = new double[n][];

            for (int row = 0; row < n; row++)
            {
                jaggetArr[row] = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(double.Parse)
                                     .ToArray();
            }

            CheckLenghtOfRows(jaggetArr, n);

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();

                string operation = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row >= 0 && row < jaggetArr.Length &&
                    col >= 0 && col < jaggetArr[row].Length)
                {
                    if (operation == "Add")
                    {
                        jaggetArr[row][col] += value;
                    }
                    else if (operation == "Subtract")
                    {
                        jaggetArr[row][col] -= value;
                    }
                }
                input = Console.ReadLine();
            }

            for (int row = 0; row < jaggetArr.Length; row++)
            {
                for (int col = 0; col < jaggetArr[row].Length; col++)
                {
                    Console.Write(jaggetArr[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static double[][] CheckLenghtOfRows(double[][] jaggetArr, int n)
        {
            for (int row = 0; row < jaggetArr.Length - 1; row++)
            {

                if (jaggetArr[row].Length == jaggetArr[row + 1].Length)
                {
                    for (int i = 0; i < jaggetArr[row].Length; i++)
                    {
                        jaggetArr[row][i] *= 2;
                        jaggetArr[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggetArr[row].Length; i++)
                    {
                        jaggetArr[row][i] /= 2;
                    }

                    for (int j = 0; j < jaggetArr[row + 1].Length; j++)
                    {
                        jaggetArr[row + 1][j] /= 2;
                    }
                }
            }
            return jaggetArr;
        }
    }
}
