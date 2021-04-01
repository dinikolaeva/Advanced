using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PeopleOver30 people = new PeopleOver30();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var age = int.Parse(input[1]);

                Person newPerson = new Person(name, age);
                people.AddMember(newPerson);
            }

            List<Person> peopleOver30 = people.GetPeopleOver30();

            foreach (Person person in peopleOver30.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
