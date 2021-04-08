using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            var positionRow = 0;
            var positionCol = 0;

            GetMatrix(n, matrix, ref positionRow, ref positionCol);

            bool isWon = false;

            for (int i = 0; i < m; i++)
            {
                var command = Console.ReadLine();

                matrix[positionRow, positionCol] = '-';

                if (command == "up")
                {
                    if (positionRow - 1 < 0)
                    {
                        positionRow = matrix.GetLength(0) - 1;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionRow = 0;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            positionRow -= 1;
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            isWon = true;
                            matrix[positionRow, positionCol] = 'f';
                            break;
                        }
                        matrix[positionRow, positionCol] = 'f';
                    }
                    else
                    {
                        positionRow -= 1;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionRow += 1;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            if (positionRow - 1 > 0)
                            {
                                positionRow -= 1;
                            }
                            else
                            {
                                positionRow = matrix.GetLength(0) - 1;
                            }
                        }

                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }
                        matrix[positionRow, positionCol] = 'f';
                    }
                }
                else if (command == "down")
                {
                    if (positionRow + 1 > matrix.GetLength(0) - 1)
                    {
                        positionRow = 0;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionRow = matrix.GetLength(0) - 1;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            positionRow += 1;
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }
                        matrix[positionRow, positionCol] = 'f';
                    }
                    else
                    {
                        positionRow += 1;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionRow -= 1;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            if (positionRow + 1 <= matrix.GetLength(0) - 1)
                            {
                                positionRow += 1;
                            }
                            else
                            {
                                positionRow = 0;
                            }
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }
                        matrix[positionRow, positionCol] = 'f';
                    }
;
                }
                else if (command == "left")
                {
                    if (positionCol - 1 < 0)
                    {
                        positionCol = matrix.GetLength(1) - 1;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionCol = 0;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            positionCol -= 1;
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }
                        matrix[positionRow, positionCol] = 'f';
                    }
                    else
                    {
                        positionCol -= 1;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionCol += 1;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            if (positionCol - 1 > 0)
                            {
                                positionCol -= 1;
                            }
                            else
                            {
                                positionCol = matrix.GetLength(1) - 1;
                            }
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }

                        matrix[positionRow, positionCol] = 'f';
                    }
                }
                else if (command == "right")
                {
                    if (positionCol + 1 > matrix.GetLength(1) - 1)
                    {
                        positionCol = 0;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionRow = matrix.GetLength(1) - 1;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            positionCol += 1;
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }
                        matrix[positionRow, positionCol] = 'f';
                    }
                    else
                    {
                        positionCol += 1;

                        if (matrix[positionRow, positionCol] == 'T')
                        {
                            positionCol -= 1;
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            if (positionCol + 1 <= matrix.GetLength(1) - 1)
                            {
                                positionCol += 1;
                            }
                            else
                            {
                                positionCol = 0;
                            }
                        }
                        
                        if (matrix[positionRow, positionCol] == 'F')
                        {
                            matrix[positionRow, positionCol] = 'f';
                            isWon = true;
                            break;
                        }

                        matrix[positionRow, positionCol] = 'f';
                    }
                }
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

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
                Console.WriteLine(); ;
            }
        }

        private static void GetMatrix(int n, char[,] matrix, ref int positionRow, ref int positionCol)
        {
            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];

                    if (matrix[row, col] == 'f')
                    {
                        positionRow = row;
                        positionCol = col;
                    }
                }
            }
        }
    }
}