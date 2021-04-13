using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;
        //private int id;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
            //this.id = 0;
        }

        public int Count { get => this.data.Count; }

        public void Add(Person person)
        {
            this.data.Add(this.Count/*or this.id = 0;*/, person);
        }

        public Person Get(int id)
        {
            return this.data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.data.ContainsKey(id))
            {
                return false;
            }

            this.data[id] = newPerson;
            return true;
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                this.data.Remove(id);
                return true;
            }
            return false;
        }
    }
}
