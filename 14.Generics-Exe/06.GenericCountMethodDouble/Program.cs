using System;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Value.Add(input);
            }

            var element = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountGreater(element));
        }
    }
}
