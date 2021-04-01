using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person newPerson = new Person("Pesho", 20);

            Console.WriteLine($"{newPerson.Name}");
            Console.WriteLine($"{newPerson.Age}");
        }
    }
}
