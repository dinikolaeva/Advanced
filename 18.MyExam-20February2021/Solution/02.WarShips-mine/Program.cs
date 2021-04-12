using System;
using System.Linq;

namespace _02.WarShips_mine
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

            int firstPlayerShips = 0;
            int secondPlayrShips = 0;

            for (int row = 0; row < n; row++)
            {
                string[] elements = Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = char.Parse(elements[col]);

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondPlayrShips++;
                    }
                }
            }

            int firstPlayerShipsDestroyed = firstPlayerShips;
            int secondPlayerhipsDestroyed = secondPlayrShips;

            for (int i = 0; i < coordinates.Length; i++)
            {
                if (firstPlayerShipsDestroyed <= 0 || secondPlayerhipsDestroyed <= 0)
                {                    
                    break;
                }

                string[] currentCoordinate = coordinates[i]
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();

                int currentRow = int.Parse(currentCoordinate[0]);
                int currentCol = int.Parse(currentCoordinate[1]);

                if (!IsValidCoordinate(n, currentRow, currentCol))
                {
                    continue;
                }
                else
                {
                    //firstPlayerCoordinates
                    if (i % 2 == 0)
                    {
                        if (matrix[currentRow, currentCol] == '>')
                        {
                            matrix[currentRow, currentCol] = 'X';
                            secondPlayerhipsDestroyed--;
                        }

                        if (matrix[currentRow, currentCol] == '#')
                        {
                            HaveMine(n, matrix, ref firstPlayerShipsDestroyed, ref secondPlayerhipsDestroyed, currentRow, currentCol);
                        }
                    }
                    //secondPlayerCoordinates
                    else
                    {
                        if (matrix[currentRow, currentCol] == '<')
                        {
                            matrix[currentRow, currentCol] = 'X';
                            firstPlayerShipsDestroyed--;
                        }

                        if (matrix[currentRow, currentCol] == '#')
                        {
                            HaveMine(n, matrix, ref firstPlayerShipsDestroyed, ref secondPlayerhipsDestroyed, currentRow, currentCol);
                        }
                    }
                }
            }

            if (firstPlayerShipsDestroyed <= 0 || secondPlayerhipsDestroyed <= 0)
            {
                if (firstPlayerShipsDestroyed > 0)
                {
                    int leftShips = (firstPlayerShips + secondPlayrShips) - (firstPlayerShipsDestroyed + secondPlayerhipsDestroyed);

                    Console.WriteLine($"Player One has won the game! {leftShips} ships have been sunk in the battle.");
                }
                else if (secondPlayerhipsDestroyed > 0)
                {
                    int leftShips = (firstPlayerShips + secondPlayrShips) - (firstPlayerShipsDestroyed + secondPlayerhipsDestroyed);

                    Console.WriteLine($"Player Two has won the game! {leftShips} ships have been sunk in the battle.");
                }
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsDestroyed} ships left. Player Two has {secondPlayerhipsDestroyed} ships left.");
            }
        }

        private static void HaveMine(int n, char[,] matrix, ref int firstPlayerShipsDestroyed, ref int secondPlayerhipsDestroyed, int currentRow, int currentCol)
        {
            //up
            if (IsValidCoordinate(n, currentRow - 1, currentCol))
            {
                if (matrix[currentRow - 1, currentCol] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow - 1, currentCol] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow - 1, currentCol] = 'X';
            }
            //upleft
            if (IsValidCoordinate(n, currentRow - 1, currentCol - 1))
            {
                if (matrix[currentRow - 1, currentCol - 1] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow - 1, currentCol - 1] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow - 1, currentCol - 1] = 'X';
            }
            //upright
            if (IsValidCoordinate(n, currentRow - 1, currentCol + 1))
            {
                if (matrix[currentRow - 1, currentCol + 1] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow - 1, currentCol + 1] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow - 1, currentCol + 1] = 'X';
            }
            //down
            if (IsValidCoordinate(n, currentRow + 1, currentCol))
            {
                if (matrix[currentRow + 1, currentCol] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow + 1, currentCol] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow + 1, currentCol] = 'X';
            }
            //downleft
            if (IsValidCoordinate(n, currentRow + 1, currentCol - 1))
            {
                if (matrix[currentRow + 1, currentCol - 1] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow + 1, currentCol - 1] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow + 1, currentCol - 1] = 'X';
            }
            //downright
            if (IsValidCoordinate(n, currentRow + 1, currentCol + 1))
            {
                if (matrix[currentRow + 1, currentCol + 1] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow + 1, currentCol + 1] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow + 1, currentCol + 1] = 'X';
            }
            //left
            if (IsValidCoordinate(n, currentRow, currentCol - 1))
            {
                if (matrix[currentRow, currentCol - 1] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow, currentCol - 1] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow, currentCol - 1] = 'X';
            }
            //rigth
            if (IsValidCoordinate(n, currentRow, currentCol + 1))
            {
                if (matrix[currentRow, currentCol + 1] == '>')
                {
                    secondPlayerhipsDestroyed--;
                }
                else if (matrix[currentRow, currentCol + 1] == '<')
                {
                    firstPlayerShipsDestroyed--;
                }
                matrix[currentRow, currentCol + 1] = 'X';
            }

            matrix[currentRow, currentCol] = 'X';
        }

        static bool IsValidCoordinate(int n, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < n && currentCol >= 0 && currentRow < n;
        }
    }
}
