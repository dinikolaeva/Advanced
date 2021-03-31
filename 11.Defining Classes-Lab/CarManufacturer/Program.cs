using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = GetTiresInfo();
            List<Engine> engines = GetEngineInfo();
            List<Car> cars = GetCarsInfo(engines, tires);

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Year >= 2017
                    && cars[i].Engine.HorsePower > 330
                    && cars[i].SumTirePressure() > 9
                    && cars[i].SumTirePressure() < 10)
                {
                    cars[i].Drive(20);
                    Console.WriteLine(cars[i].WhoAmI());
                }
            }
        }

        private static List<Car> GetCarsInfo(List<Engine> engines, List<Tire[]> tires)
        {
            string specialCommand = Console.ReadLine();

            var cars = new List<Car>();

            while (specialCommand != "Show special")
            {
                var carInfo = specialCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var make = carInfo[0];
                var model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tireIndex = int.Parse(carInfo[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);

                cars.Add(car);

                specialCommand = Console.ReadLine();
            }
            return cars;
        }

        private static List<Engine> GetEngineInfo()
        {
            var list = new List<Engine>();
            string input = Console.ReadLine();

            while (input != "Engines done")
            {
                var engineInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var horsePower = int.Parse(engineInfo[0]);
                var cubicCapacity = double.Parse(engineInfo[1]);
                var engine = new Engine(horsePower, cubicCapacity);
                list.Add(engine);

                input = Console.ReadLine();
            }
            return list;
        }

        private static List<Tire[]> GetTiresInfo()
        {
            var list = new List<Tire[]>();
            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                var tiresInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();
                var currentTires = new List<Tire>();

                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    var year = int.Parse(tiresInfo[i]);
                    var pressure = double.Parse(tiresInfo[i + 1]);
                    var tire = new Tire(year, pressure);
                    currentTires.Add(tire);
                }
                list.Add(currentTires.ToArray());

                command = Console.ReadLine();
            }

            return list;
        }
    }
}
