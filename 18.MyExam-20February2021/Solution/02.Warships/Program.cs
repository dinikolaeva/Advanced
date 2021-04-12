using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] coordinates = Console.ReadLine()
                                          .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();


            char[,] matrix = new char[n, n];

            int countOfPlayer1Ships = 0;
            int countOfPlayer2Ships = 0;

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == '<')
                    {
                        countOfPlayer1Ships++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        countOfPlayer2Ships++;
                    }
                }
            }

            int stratShipsPlayer1 = countOfPlayer1Ships;
            int startShipsPlayer2 = countOfPlayer2Ships;

            for (int i = 0; i < coordinates.Length; i++)
            {

                if (countOfPlayer1Ships <= 0 || countOfPlayer2Ships <= 0)
                {
                    break;
                }

                string[] currentCoordinate = coordinates[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(currentCoordinate[0]);
                int col = int.Parse(currentCoordinate[1]);

                if (IsValidCoordinates(row, col, n) == false)
                {
                    if (i % 2 == 0)
                    {
                        if (matrix[row, col] == '>')
                        {
                            matrix[row, col] = 'X';
                            countOfPlayer2Ships--;
                        }

                        if (matrix[row, col] == '#')
                        {
                            matrix = Mine(n, matrix, ref stratShipsPlayer1, ref startShipsPlayer2, ref row, ref col);
                        }
                    }
                }
                else
                {
                    if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        countOfPlayer1Ships--;
                    }

                    if (matrix[row, col] == '#')
                    {
                        matrix = Mine(n, matrix, ref stratShipsPlayer1, ref startShipsPlayer2, ref row, ref col);
                    }
                }
            }

            if (countOfPlayer1Ships <= 0 || countOfPlayer2Ships <= 0)
            {
                if (countOfPlayer1Ships > 0)
                {
                    int sumOfDestroyedShips = startShipsPlayer2 + (stratShipsPlayer1 - countOfPlayer1Ships);
                    Console.WriteLine($"Player One has won the game! {sumOfDestroyedShips} ships have been sunk in the battle.");
                }
                else
                {
                    int sumOfDestroyedShips = stratShipsPlayer1 + (startShipsPlayer2 - countOfPlayer2Ships);
                    Console.WriteLine($"Player Two has won the game! {sumOfDestroyedShips} ships have been sunk in the battle.");
                }
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {countOfPlayer1Ships} ships left. Player Two has {countOfPlayer2Ships} ships left.");
            }

            static bool IsValidCoordinates(int row, int col, int n)
            {
                return row >= 0 && row < n && col >= 0 && col < n;
            }

            static char[,] Mine(int n, char[,] matrix, ref int stratShipsPlayer1, ref int startShipsPlayer2, ref int row, ref int col)
            {
                if (IsValidCoordinates(row - 1, col, n))
                {
                    row -= 1;
                    if (matrix[row - 1, col] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row - 1, col] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row + 1, col, n))
                {
                    row += 1;
                    if (matrix[row + 1, col] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row + 1, col] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row, col - 1, n))
                {
                    col -= 1;
                    if (matrix[row, col - 1] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row, col - 1] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row, col + 1, n))
                {
                    col += 1;
                    if (matrix[row, col + 1] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row, col + 1] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row - 1, col - 1, n))
                {
                    row -= 1;
                    col -= 1;
                    if (matrix[row - 1, col - 1] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row - 1, col - 1] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row + 1, col + 1, n))
                {
                    row += 1;
                    col += 1;
                    if (matrix[row + 1, col + 1] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row + 1, col + 1] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row - 1, col + 1, n))
                {
                    row -= 1;
                    col += 1;
                    if (matrix[row - 1, col + 1] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row - 1, col + 1] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                if (IsValidCoordinates(row + 1, col - 1, n))
                {
                    row += 1;
                    col -= 1;
                    if (matrix[row + 1, col - 1] == '<')
                    {
                        stratShipsPlayer1--;
                    }

                    if (matrix[row + 1, col - 1] == '>')
                    {
                        startShipsPlayer2--;
                    }
                }

                matrix[row, col] = 'X';
                return matrix;
            }
        }
    }
}
