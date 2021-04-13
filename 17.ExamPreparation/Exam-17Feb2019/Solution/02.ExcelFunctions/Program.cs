using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] matrix = new string[n][];

            for (int row = 0; row < n; row++)
            {
                var lines = Console.ReadLine()
                                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                matrix[row] = lines;
            }

            var command = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

            var action = command[0];
            var header = command[1];

            int index = Array.IndexOf(matrix[0], header);

            if (action == "hide")
            {
                for (int row = 0; row < n; row++)
                {
                    var lines = new List<string>(matrix[row]);
                    lines.RemoveAt(index);
                    Console.WriteLine(string.Join(" | ", lines));
                    //matrix[row] = lines.ToArray();
                }
            }
            else if (action == "sort")
            {
                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                matrix = matrix.OrderBy(m => m[index]).ToArray();

                foreach (var row in matrix)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (action == "filter")
            {
                var value = command[2];
                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int row = 0; row < n; row++)
                {
                    if (matrix[row][index] == value)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }
        }
    }
}
