using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
        public int Count => Cars.Count;
        public int Capacity { get; set; }

        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (Count >= Capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                Cars.Remove(Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return $"Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x=>x.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registration in RegistrationNumbers)
            {
                Cars.RemoveAll(x => x.RegistrationNumber == registration);
            }
        }
    }
}
