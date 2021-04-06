using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (Capacity > this.data.Count)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = data.Find(x => x.Name == name);

            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet surchedPet = data.Find(x => x.Name == name && x.Owner == owner);

            if (data.Contains(surchedPet))
            {
                return surchedPet;
            }
            return null;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = data.OrderByDescending(x => x.Age).First();
            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");

            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        public int Capacity { get; set; }
    }
}
