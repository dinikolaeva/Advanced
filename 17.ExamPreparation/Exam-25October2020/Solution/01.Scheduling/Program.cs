using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = Console.ReadLine()
                               .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse);
            var queue = Console.ReadLine()
                               .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse);
            var killTask = int.Parse(Console.ReadLine());

            var tasks = new Stack<int>(stack);
            var threads = new Queue<int>(queue);

            while (true)
            {
                var currentTask = tasks.Peek();
                var currentThreads = threads.Peek();

                if (killTask != currentTask)
                {
                    if (currentThreads >= currentTask)
                    {
                        tasks.Pop();
                        threads.Dequeue();
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {killTask}");
            Console.WriteLine(string.Join(' ',threads));
        }
    }
}
