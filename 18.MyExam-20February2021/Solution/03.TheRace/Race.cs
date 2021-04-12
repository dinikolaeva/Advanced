using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public int Count { get => this.data.Count; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Racer Racer)
        {
            if (this.Capacity > this.Count)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            Racer wantedRacer = data.Find(x => x.Name == name);

            if (data.Contains(wantedRacer))
            {
                data.Remove(wantedRacer);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = data.OrderByDescending(x => x.Age).First();
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer wantedRacer = data.Find(x => x.Name == name);

            if (data.Contains(wantedRacer))
            {
                return wantedRacer;
            }
            return null;
        }

        public Racer GetFastestRacer()
        {
            Racer wantedRacer = data.OrderByDescending(x => x.Car.Speed).First();

            if (data.Contains(wantedRacer))
            {
                return wantedRacer;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
