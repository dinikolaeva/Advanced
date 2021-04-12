using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            int index = data.FindIndex(x => x.Manufacturer == manufacturer &&
                                            x.Model == model);

            if (index >= 0)
            {
                data.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car GetLatestCar()
        {
           if (Count == 0)
            {
                return null;
            }
            else
            {
                Car car = data.OrderByDescending(x => x.Year).First();
                return car;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.Find(x => x.Manufacturer == manufacturer && x.Model == model);

            if (data.Contains(car))
            {
                return car;
            }
            else
            {
                return null;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }


        public int Count { get => this.data.Count; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }
}
