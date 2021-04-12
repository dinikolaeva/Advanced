using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            const int claimedItems = 100;

            var firstLootBox = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            var secondLootBox = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            var firstQueue = new Queue<int>(firstLootBox);
            var secondStack = new Stack<int>(secondLootBox);

            var sumOfClimedItems = 0;

            while (true)
            {
                if (firstQueue.Count == 0 || secondStack.Count == 0)
                {
                    break;
                }

                var currentQueueItem = firstQueue.Peek();
                var currentStackItem = secondStack.Peek();
                var currentSum = currentQueueItem + currentStackItem;

                if (currentSum % 2 == 0)
                {
                    sumOfClimedItems += currentSum;
                    firstQueue.Dequeue();
                    secondStack.Pop();
                }
                else
                {
                    firstQueue.Enqueue(currentStackItem);
                    secondStack.Pop();
                }
            }

            if (firstQueue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondStack.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumOfClimedItems >= claimedItems)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfClimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfClimedItems}");
            }
        }
    }
}
