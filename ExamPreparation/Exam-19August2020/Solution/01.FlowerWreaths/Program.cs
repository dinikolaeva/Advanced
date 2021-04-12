using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            const int flowerNeeded = 15;
            const int targetWreaths = 5;

            var lilies = Console.ReadLine()
                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            var roses = Console.ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            var liliesStack = new Stack<int>(lilies);
            var rosesQueue = new Queue<int>(roses);

            int countOfWreaths = 0;
            int sumOfRestFlowers = 0;

            while (liliesStack.Count > 0 && rosesQueue.Count > 0)
            {
                var currentLily = liliesStack.Peek();
                var currentRose = rosesQueue.Peek();

                var sumOfCurrentFlowers = currentLily + currentRose;

                if (sumOfCurrentFlowers == flowerNeeded)
                {
                    countOfWreaths++;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
                else if (sumOfCurrentFlowers > flowerNeeded)
                {
                    while (sumOfCurrentFlowers > flowerNeeded)
                    {
                        currentLily -= 2;
                        sumOfCurrentFlowers = currentLily + currentRose;
                    }

                    if (sumOfCurrentFlowers == flowerNeeded)
                    {
                        countOfWreaths++;
                        liliesStack.Pop();
                        rosesQueue.Dequeue();
                    }
                    else if (sumOfCurrentFlowers < flowerNeeded)
                    {
                        sumOfRestFlowers += sumOfCurrentFlowers;
                        liliesStack.Pop();
                        rosesQueue.Dequeue();
                    }
                }
                else if (sumOfCurrentFlowers < flowerNeeded)
                {
                    sumOfRestFlowers += sumOfCurrentFlowers;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
            }

            if (sumOfRestFlowers > 0)
            {
                int whreathsExtra = sumOfRestFlowers / flowerNeeded;
                countOfWreaths += whreathsExtra;
            }

            if (countOfWreaths >= targetWreaths)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                var whreathsNeeded = targetWreaths - countOfWreaths;
                Console.WriteLine($"You didn't make it, you need {whreathsNeeded} wreaths more!");
            }
        }
    }
}
