using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = word => word[0] == word.ToUpper()[0];

            var input = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Where(isUpper)
                               .ToArray();

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }

        }
    }
}
