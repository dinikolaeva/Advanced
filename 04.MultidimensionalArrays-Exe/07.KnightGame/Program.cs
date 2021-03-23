using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];

            GetMatrix(chessBoard);

            int removedKnights = 0;
            int maxAttackRow = 0;
            int maxAttackCol = 0;

            while (true)
            {
                int maxAttackCounter = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currentChar = chessBoard[row, col];
                        int currentAttacks = 0;

                        if (currentChar == 'K')
                        {
                            currentAttacks = GetCountOfCurrentAttack(chessBoard, row, col, currentAttacks);

                            if (currentAttacks > maxAttackCounter)
                            {
                                maxAttackCounter = currentAttacks;
                                maxAttackRow = row;
                                maxAttackCol = col;
                            }
                        }
                    }
                }

                if (maxAttackCounter > 0)
                {
                    chessBoard[maxAttackRow, maxAttackCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static int GetCountOfCurrentAttack(char[,] chessBoard, int row, int col, int currentAttacks)
        {
            if (IsValid(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                currentAttacks++;
            }

            if (IsValid(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
            {
                currentAttacks++;
            }

            return currentAttacks;
        }

        private static bool IsValid(char[,] chessBoard, int row, int col)
        {
            return row >= 0 && row < chessBoard.GetLength(0) &&
                   col >= 0 && col < chessBoard.GetLength(1);
        }

        private static void GetMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] currentChar = Console.ReadLine().ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = currentChar[col];
                }
            }
        }
    }
}
