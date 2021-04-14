using System;
using System.Collections.Generic;
using System.Linq;

namespace _19.MyRetakeExam_14April2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var hats = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            var scarfs = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            var pairsList = new List<int>();
            var stackHats = new Stack<int>(hats);
            var queueScarfs = new Queue<int>(scarfs);

            while (stackHats.Count != 0 && queueScarfs.Count != 0)
            {
                var currentHat = stackHats.Peek();
                var currentScarf = queueScarfs.Peek();

                if (currentScarf > currentHat)
                {
                    stackHats.Pop();
                }
                else if (currentScarf == currentHat)
                {
                    queueScarfs.Dequeue();
                    stackHats.Pop();
                    stackHats.Push(currentHat + 1);
                }
                else
                {
                    var set = currentHat + currentScarf;
                    queueScarfs.Dequeue();
                    stackHats.Pop();
                    pairsList.Add(set);
                }
            }

            Console.WriteLine($"The most expensive set is: {pairsList.Max()}");
            Console.WriteLine(string.Join(' ', pairsList));
        }
    }
}
