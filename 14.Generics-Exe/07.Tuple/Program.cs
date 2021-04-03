using System;
using System.Linq;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Tuple<string, string> person = new Tuple<string, string>(input[0] + ' ' + input[1],
                input[2]);
            Console.WriteLine($"{person.Item1} -> {person.Item2}");

            input = Console.ReadLine().Split();
            Tuple<string, int> litres = new Tuple<string, int>(input[0], int.Parse(input[1]));
            Console.WriteLine($"{litres.Item1} -> {litres.Item2}");

            input = Console.ReadLine().Split();
            Tuple<int, double> numbers = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine($"{numbers.Item1} -> {numbers.Item2}");
        }
    }
}
