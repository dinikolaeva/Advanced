using System;

namespace Repository
{
    public class Person
    {
        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

    }
}
