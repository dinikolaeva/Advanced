using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bread = 25;
            const int cake = 50;
            const int pastry = 75;
            const int fruitPie = 100;

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray();

            var queue = new Queue<int>(input);
            var stack = new Stack<int>(numbers);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            while (true)
            {
                if (stack.Count == 0 || queue.Count == 0)
                {
                    break;
                }
                else
                {
                    var sumToCheck = queue.Peek() + stack.Peek();

                    if (sumToCheck == bread)
                    {
                        stack.Pop();
                        queue.Dequeue();
                        breadCount++;
                    }
                    else if (sumToCheck == cake)
                    {
                        stack.Pop();
                        queue.Dequeue();
                        cakeCount++;
                    }
                    else if (sumToCheck == pastry)
                    {
                        stack.Pop();
                        queue.Dequeue();
                        pastryCount++;
                    }
                    else if (sumToCheck == fruitPie)
                    {
                        stack.Pop();
                        queue.Dequeue();
                        fruitPieCount++;
                    }
                    else
                    {
                        queue.Dequeue();
                        var nextElement = stack.Pop();
                        nextElement += 3;
                        stack.Push(nextElement);
                    }
                }
            }

            if (breadCount > 0 && cakeCount > 0 &&
                pastryCount > 0 && fruitPie > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queue.Count > 0)
            {
                Console.Write($"Liquids left: ");
                Console.WriteLine(string.Join(", ", queue));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stack.Count > 0)
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(string.Join(", ", stack));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
