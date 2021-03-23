using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Reed a string matrix
            int[] sizeInfo = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int rows = sizeInfo[0];
            int cols = sizeInfo[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] colElements = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            //2.Reed the commands
            string[] input = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            while (input[0] != "END")
            {
                string command = input[0];
                // 3.Check command - valid or not. If not -"Invalid input!" and continue.

                if (command == "swap" && input.Length == 5)
                {
                    int swapElementRow = int.Parse(input[1]);
                    int swapElementCol = int.Parse(input[2]);
                    int movedElementRow = int.Parse(input[3]);
                    int movedElementCol = int.Parse(input[4]);

                    if (swapElementRow >= 0 && swapElementCol >= 0 &&
                        movedElementRow >= 0 && movedElementCol >= 0 &&
                        swapElementRow <= sizeInfo[0] &&
                        swapElementCol <= sizeInfo[1] &&
                        movedElementRow <= sizeInfo[0] &&
                        movedElementCol <= sizeInfo[1])
                    {
                        string firstElement = matrix[swapElementRow, swapElementCol];
                        string secondElement = matrix[movedElementRow, movedElementCol];
                        //4.Swap the element on given index
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (swapElementRow == row && swapElementCol == col)
                                {
                                    matrix[row, col] = secondElement;
                                }
                                else if (movedElementRow == row && movedElementCol == col)
                                {
                                    matrix[row, col] = firstElement;
                                }
                            }
                        }
                        //5.Print the matrix on evry step
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                command = input[0];
            }
            //6.Program finish with "END" command
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
