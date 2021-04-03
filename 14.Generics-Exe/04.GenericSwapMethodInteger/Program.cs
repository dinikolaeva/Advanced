using System;

namespace _04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Value.Add(input);
            }

            var indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int oldIndex = int.Parse(indexes[0]);
            int newIndex = int.Parse(indexes[1]);

            box.Swap(oldIndex, newIndex);
            Console.WriteLine(box);
        }
    }
}
