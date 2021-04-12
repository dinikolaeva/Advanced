using System;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            var row = 0;
            var col = 0;

            for (int i = 0; i < n; i++)
            {
                var elementsCol = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = elementsCol[j];

                    if (matrix[i, j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            var collectMoney = 0;

            while (true)
            {
                var direction = Console.ReadLine();

                if (direction == "up")
                {
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] == '-')
                        {
                            matrix[row - 1, col] = 'S';
                            matrix[row, col] = '-';
                            row -= 1;
                        }
                        else if (char.IsDigit(matrix[row - 1, col]))
                        {
                            collectMoney += int.Parse(matrix[row - 1, col].ToString());
                            matrix[row, col] = '-';
                            matrix[row - 1, col] = 'S';
                            row -= 1;
                        }
                        else if (matrix[row - 1, col] == 'O')
                        {
                            matrix[row - 1, col] = '-';
                            matrix[row, col] = '-';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'O')
                                    {
                                        matrix[rows, cols] = 'S';

                                        row = rows;
                                        col = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[row, col] = '-';
                        break;
                    }
                }
                else if (direction == "down")
                {
                    if (row + 1 < n)
                    {
                        if (matrix[row + 1, col] == '-')
                        {
                            matrix[row + 1, col] = 'S';
                            matrix[row, col] = '-';
                            row += 1;
                        }
                        else if (char.IsDigit(matrix[row + 1, col]))
                        {
                            collectMoney += int.Parse(matrix[row + 1, col].ToString());
                            matrix[row, col] = '-';
                            matrix[row + 1, col] = 'S';
                            row += 1;
                        }
                        else if (matrix[row + 1, col] == 'O')
                        {
                            matrix[row + 1, col] = '-';
                            matrix[row, col] = '-';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'O')
                                    {
                                        matrix[rows, cols] = 'S';

                                        row = rows;
                                        col = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[row, col] = '-';
                        break;
                    }
                }
                else if (direction == "left")
                {
                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] == '-')
                        {
                            matrix[row, col - 1] = 'S';
                            matrix[row, col] = '-';
                            col -= 1;
                        }
                        else if (char.IsDigit(matrix[row, col - 1]))
                        {
                            collectMoney += int.Parse(matrix[row, col - 1].ToString());
                            matrix[row, col] = '-';
                            matrix[row, col - 1] = 'S';
                            col -= 1;
                        }
                        else if (matrix[row, col - 1] == 'O')
                        {
                            matrix[row, col - 1] = '-';
                            matrix[row, col] = '-';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'O')
                                    {
                                        matrix[rows, cols] = 'S';

                                        row = rows;
                                        col = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[row, col] = '-';
                        break;
                    }
                }
                else if (direction == "right")
                {
                    if (col + 1 < n)
                    {
                       if (matrix[row, col + 1] == '-')
                        {
                            matrix[row, col + 1] = 'S';
                            matrix[row, col] = '-';
                            col += 1;
                        }
                        else if (char.IsDigit(matrix[row, col + 1]))
                        {
                            collectMoney += int.Parse(matrix[row, col + 1].ToString());
                            matrix[row, col] = '-';
                            matrix[row, col + 1] = 'S';
                            col += 1;
                        }
                        else if (matrix[row, col + 1] == 'O')
                        {
                            matrix[row, col + 1] = '-';
                            matrix[row, col] = '-';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (matrix[rows, cols] == 'O')
                                    {
                                        matrix[rows, cols] = 'S';

                                        row = rows;
                                        col = cols;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[row, col] = '-';
                        break;
                    }
                }
                if (collectMoney >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }

            }

            Console.WriteLine($"Money: {collectMoney}");

            PrintMatrix(matrix);
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
