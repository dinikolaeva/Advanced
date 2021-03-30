using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Action<string> text = GetPrint(names);

            foreach (var name in names)
            {
                text(name);
            }
        }

        private static Action<string> GetPrint(string[] names)
        {
            return name => Console.WriteLine(name);
        }
    }
}
