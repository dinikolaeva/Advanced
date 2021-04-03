using System;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Value.Add(input);
            }

            var element = Console.ReadLine();

            Console.WriteLine(box.CountGreater(element));
        }
    }
}
