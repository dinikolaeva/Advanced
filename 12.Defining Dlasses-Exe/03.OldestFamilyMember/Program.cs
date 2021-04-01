using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family members = new Family();

            for (int i = 1; i <= n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person newPerson = new Person(name, age);
                members.AddMember(newPerson);
            }

            Person oldest = members.GetOldestMember(members);
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
