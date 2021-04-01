using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }
       
        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember(Family members)
        {
            var oldestMemberAge = members.Members.Select(x => x.Age).Max();
            var oldestMemberName = members.Members.Where(x => x.Age == oldestMemberAge).Select(x => x.Name).ToList()[0];

            Person oldest = new Person(oldestMemberName, oldestMemberAge);
            return oldest;
        }
    }
}
