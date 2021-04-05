using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> collection = null;

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var inputCmd = input[0];

                    if (inputCmd == "Create")
                    {
                        List<string> elements = input.Skip(1).ToList();
                        collection = new ListyIterator<string>(elements);
                    }
                    else if (inputCmd == "Move")
                    {
                        Console.WriteLine(collection.Move());
                    }
                    else if (inputCmd == "HasNext")
                    {
                        Console.WriteLine(collection.HasNext());
                    }
                    else if (inputCmd == "Print")
                    {
                        collection.Print();
                    }
                }
                catch(InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                

                command = Console.ReadLine();
            }
        }
    }
}
