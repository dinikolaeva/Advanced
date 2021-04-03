using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Tuple<string, string, string> person = new Tuple<string, string, string>(input[0] + ' '
                + input[1], input[2], input[3]);
            Console.WriteLine($"{person.Item1} -> {person.Item2} -> {person.Item3}");

            input = Console.ReadLine().Split();
            bool isDrunk = input[2] == "drunk" ? true : false;
            Tuple<string, int, bool> litres = new Tuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
            Console.WriteLine($"{litres.Item1} -> {litres.Item2} -> {litres.Item3}");

            input = Console.ReadLine().Split();
            Tuple<string, double, string> numbers = new Tuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine($"{numbers.Item1} -> {numbers.Item2} -> {numbers.Item3}");
        }
    }
}
