using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int daturaBombs = 40;
            const int cherryBombs = 60;
            const int smokeDecoyBombs = 120;

            const int daturaTarget = 3;
            const int cherryBobmsTarget = 3;
            const int smokeDecoyBombsTarget = 3;

            var bombEffect = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            var bombCasing = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            var bombEffectQueue = new Queue<int>(bombEffect);
            var bombCasingStack = new Stack<int>(bombCasing);

            int countOfDaturaBombs = 0;
            int countOfCherryBombs = 0;
            int countOfSmokeDecoyBombs = 0;
            bool isFill = false;

            while (bombEffectQueue.Count > 0 && bombCasingStack.Count > 0)
            {
                if (countOfDaturaBombs >= daturaTarget &&
                    countOfCherryBombs >= cherryBobmsTarget &&
                    countOfSmokeDecoyBombs >= smokeDecoyBombsTarget)
                {
                    isFill = true;
                    break;
                }

                var currentEffect = bombEffectQueue.Peek();
                var currentCasing = bombCasingStack.Peek();
                var currentSum = currentEffect + currentCasing;

                if (currentSum == daturaBombs)
                {
                    countOfDaturaBombs++;
                }
                else if (currentSum == cherryBombs)
                {
                    countOfCherryBombs++;
                }
                else if (currentSum == smokeDecoyBombs)
                {
                    countOfSmokeDecoyBombs++;
                }
                else
                {
                    while (true)
                    {
                        currentCasing -= 5;
                        currentSum = currentEffect + currentCasing;

                        if (currentSum == daturaBombs)
                        {
                            countOfDaturaBombs++;
                            break;
                        }
                        else if (currentSum == cherryBombs)
                        {
                            countOfCherryBombs++;
                            break;
                        }
                        else if (currentSum == smokeDecoyBombs)
                        {
                            countOfSmokeDecoyBombs++;
                            break;
                        }
                    }
                }

                bombEffectQueue.Dequeue();
                bombCasingStack.Pop();
            }

            if (isFill == true)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffectQueue.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffectQueue)}");
            }

            if (bombCasingStack.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasingStack)}");
            }

            Console.WriteLine($"Cherry Bombs: {countOfCherryBombs}");
            Console.WriteLine($"Datura Bombs: {countOfDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {countOfSmokeDecoyBombs}");
        }
    }
}
