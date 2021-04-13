using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {

            var leftSocks = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            var rightSocks = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            var pairsList = new List<int>();
            var stackLeftSocks = new Stack<int>(leftSocks);
            var queueRightSocks = new Queue<int>(rightSocks);

            while (stackLeftSocks.Count != 0 && queueRightSocks.Count != 0)
            {
                var currentLeft = stackLeftSocks.Peek();
                var currentRight = queueRightSocks.Peek();

                if (currentRight > currentLeft)
                {
                    stackLeftSocks.Pop();
                }
                else if (currentRight == currentLeft)
                {
                    queueRightSocks.Dequeue();
                    stackLeftSocks.Pop();
                    stackLeftSocks.Push(currentLeft + 1);
                }
                else
                {
                    var set = currentLeft + currentRight;
                    queueRightSocks.Dequeue();
                    stackLeftSocks.Pop();
                    pairsList.Add(set);
                }
            }

            Console.WriteLine(pairsList.Max());
            Console.WriteLine(string.Join(' ', pairsList));
        }
    }
}
