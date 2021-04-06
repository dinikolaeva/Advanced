using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            const int targetPollinatedFlowers = 5;

            int n = int.Parse(Console.ReadLine());

            char[,] beeTerritory = new char[n, n];

            var currentRow = 0;
            var currentCol = 0;
            var countOfPollinatedFlower = 0;

            for (int row = 0; row < n; row++)
            {
                var elements = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    beeTerritory[row, col] = elements[col];

                    if (beeTerritory[row, col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "up")
                {
                    if (currentRow - 1 >= 0)
                    {
                        if (beeTerritory[currentRow - 1, currentCol] == 'O')
                        {
                            if (currentRow - 2 >= 0)
                            {
                                beeTerritory[currentRow, currentCol] = '.';
                                beeTerritory[currentRow - 1, currentCol] = '.';

                                if (beeTerritory[currentRow - 2, currentCol] == 'f')
                                {
                                    countOfPollinatedFlower++;
                                }

                                beeTerritory[currentRow - 2, currentCol] = 'B';
                                currentRow -= 2;
                            }
                            else
                            {
                                Console.WriteLine("The bee got lost!");
                                beeTerritory[currentRow, currentCol] = '.';
                                break;
                            }

                        }
                        else if (beeTerritory[currentRow - 1, currentCol] != 'O')
                        {
                            if (beeTerritory[currentRow - 1, currentCol] == 'f')
                            {
                                countOfPollinatedFlower++;
                            }
                            beeTerritory[currentRow, currentCol] = '.';
                            beeTerritory[currentRow - 1, currentCol] = 'B';
                            currentRow -= 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        beeTerritory[currentRow, currentCol] = '.';
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (currentRow + 1 < n)
                    {
                        if (beeTerritory[currentRow + 1, currentCol] == 'O')
                        {
                            if (currentRow + 2 >= 0)
                            {
                                beeTerritory[currentRow, currentCol] = '.';
                                beeTerritory[currentRow + 1, currentCol] = '.';

                                if (beeTerritory[currentRow + 2, currentCol] == 'f')
                                {
                                    countOfPollinatedFlower++;
                                }

                                beeTerritory[currentRow + 2, currentCol] = 'B';
                                currentRow += 2;
                            }
                            else
                            {
                                Console.WriteLine("The bee got lost!");
                                beeTerritory[currentRow, currentCol] = '.';
                                break;
                            }

                        }
                        else if (beeTerritory[currentRow + 1, currentCol] != 'O')
                        {
                            if (beeTerritory[currentRow + 1, currentCol] == 'f')
                            {
                                countOfPollinatedFlower++;
                            }
                            beeTerritory[currentRow, currentCol] = '.';
                            beeTerritory[currentRow + 1, currentCol] = 'B';
                            currentRow += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        beeTerritory[currentRow, currentCol] = '.';
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (currentCol - 1 >= 0)
                    {
                        if (beeTerritory[currentRow, currentCol - 1] == 'O')
                        {
                            if (currentCol - 2 >= 0)
                            {
                                beeTerritory[currentRow, currentCol] = '.';
                                beeTerritory[currentRow, currentCol - 1] = '.';

                                if (beeTerritory[currentRow, currentCol - 2] == 'f')
                                {
                                    countOfPollinatedFlower++;
                                }

                                beeTerritory[currentRow, currentCol - 2] = 'B';
                                currentCol -= 2;
                            }
                            else
                            {
                                Console.WriteLine("The bee got lost!");
                                beeTerritory[currentRow, currentCol] = '.';
                                break;
                            }

                        }
                        else if (beeTerritory[currentRow, currentCol - 1] != 'O')
                        {
                            if (beeTerritory[currentRow, currentCol - 1] == 'f')
                            {
                                countOfPollinatedFlower++;
                            }
                            beeTerritory[currentRow, currentCol] = '.';
                            beeTerritory[currentRow, currentCol - 1] = 'B';
                            currentCol -= 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        beeTerritory[currentRow, currentCol] = '.';
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (currentCol + 1 < n)
                    {
                        if (beeTerritory[currentRow, currentCol + 1] == 'O')
                        {
                            if (currentCol + 2 >= 0)
                            {
                                beeTerritory[currentRow, currentCol] = '.';
                                beeTerritory[currentRow, currentCol + 1] = '.';

                                if (beeTerritory[currentRow, currentCol + 2] == 'f')
                                {
                                    countOfPollinatedFlower++;
                                }

                                beeTerritory[currentRow, currentCol + 2] = 'B';
                                currentCol += 2;
                            }
                            else
                            {
                                Console.WriteLine("The bee got lost!");
                                beeTerritory[currentRow, currentCol] = '.';
                                break;
                            }

                        }
                        else if (beeTerritory[currentRow, currentCol + 1] != 'O')
                        {
                            if (beeTerritory[currentRow, currentCol + 1] == 'f')
                            {
                                countOfPollinatedFlower++;
                            }
                            beeTerritory[currentRow, currentCol] = '.';
                            beeTerritory[currentRow, currentCol + 1] = 'B';
                            currentCol += 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    beeTerritory[currentRow, currentCol] = '.';
                    break;
                }

                command = Console.ReadLine();
            }

            if (countOfPollinatedFlower >= targetPollinatedFlowers)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countOfPollinatedFlower} flowers!");
            }
            else
            {
                var flowersNeeded = targetPollinatedFlowers - countOfPollinatedFlower;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {flowersNeeded} flowers more");
            }

            for (int row = 0; row < beeTerritory.GetLength(0); row++)
            {
                for (int col = 0; col < beeTerritory.GetLength(1); col++)
                {
                    Console.Write(beeTerritory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
