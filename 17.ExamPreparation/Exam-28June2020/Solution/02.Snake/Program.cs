using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int foodNeeded = 10;

            int n = int.Parse(Console.ReadLine());

            var positionRow = 0;
            var positionCol = 0;

            char[,] territory = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = elements[col];

                    if (territory[row, col] == 'S')
                    {
                        positionRow = row;
                        positionCol = col;
                    }
                }
            }

            var command = Console.ReadLine();
            int foodQuantity = 0;

            while (true)
            {             
                if (command == "up")
                {
                    if (positionRow - 1 >= 0)
                    {
                        if (territory[positionRow - 1, positionCol] == 'B')
                        {
                            territory[positionRow, positionCol] = '.';
                            territory[positionRow - 1, positionCol] = '.';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (territory[rows, cols] == 'B')
                                    {
                                        positionRow = rows;
                                        positionCol = cols;
                                        territory[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (territory[positionRow - 1, positionCol] == '*')
                            {
                                foodQuantity++;
                            }

                            territory[positionRow - 1, positionCol] = 'S';
                            territory[positionRow, positionCol] = '.';
                            positionRow -= 1;
                        }
                    }
                    else
                    {
                        territory[positionRow, positionCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (positionRow + 1 < n)
                    {
                        if (territory[positionRow + 1, positionCol] == 'B')
                        {
                            territory[positionRow, positionCol] = '.';
                            territory[positionRow + 1, positionCol] = '.';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (territory[rows, cols] == 'B')
                                    {
                                        positionRow = rows;
                                        positionCol = cols;
                                        territory[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (territory[positionRow + 1, positionCol] == '*')
                            {
                                foodQuantity++;
                            }

                            territory[positionRow, positionCol] = '.';
                            territory[positionRow + 1, positionCol] = 'S';
                            positionRow += 1;
                        }
                    }
                    else
                    {
                        territory[positionRow, positionCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (positionCol - 1 >= 0)
                    {
                        if (territory[positionRow, positionCol - 1] == 'B')
                        {
                            territory[positionRow, positionCol] = '.';
                            territory[positionRow, positionCol - 1] = '.';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (territory[rows, cols] == 'B')
                                    {
                                        positionRow = rows;
                                        positionCol = cols;
                                        territory[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (territory[positionRow, positionCol - 1] == '*')
                            {
                                foodQuantity++;
                            }

                            territory[positionRow, positionCol - 1] = 'S';
                            territory[positionRow, positionCol] = '.';
                            positionCol -= 1;
                        }
                    }
                    else
                    {
                        territory[positionRow, positionCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (positionCol + 1 < n)
                    {
                        if (territory[positionRow, positionCol + 1] == 'B')
                        {
                            territory[positionRow, positionCol] = '.';
                            territory[positionRow, positionCol + 1] = '.';

                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (territory[rows, cols] == 'B')
                                    {
                                        positionRow = rows;
                                        positionCol = cols;
                                        territory[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (territory[positionRow, positionCol + 1] == '*')
                            {
                                foodQuantity++;
                            }

                            territory[positionRow, positionCol + 1] = 'S';
                            territory[positionRow, positionCol] = '.';
                            positionCol += 1;
                        }
                    }
                    else
                    {
                        territory[positionRow, positionCol] = '.';
                        Console.WriteLine("Game over!");
                        break;
                    }
                }

                if (foodQuantity == foodNeeded)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (foodQuantity == foodNeeded)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
