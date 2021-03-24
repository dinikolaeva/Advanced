using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var studentsAndGardes = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string nameOfStudent = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentsAndGardes.ContainsKey(nameOfStudent))
                {
                    studentsAndGardes[nameOfStudent] = new List<decimal>();
                }
                studentsAndGardes[nameOfStudent].Add(grade);
            }

            foreach (var student in studentsAndGardes)
            {
                var grades = student.Value;
                Console.Write($"{student.Key} -> ");
                foreach (var garde in grades)
                {
                    Console.Write($"{garde:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
