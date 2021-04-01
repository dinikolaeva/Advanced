using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class PeopleOver30
    {
        public PeopleOver30()
        {
            Members = new List<Person>();
        }

        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public List<Person> GetPeopleOver30()
        {
            return Members.Where(x => x.Age > 30).ToList();
        }
    }
}
