using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);
                var displacement = 0;
                var efficiency = "n/a";

                if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                }
                else if (input.Length == 3)
                {                    
                    if (char.IsLetter(char.Parse(input[2][0].ToString())))
                    {
                        efficiency = input[2];
                    }
                    else
                    {
                        displacement = int.Parse(input[2]);
                    }
                }
                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                var engineModel = input[1];
                int weight = 0;
                string color = "n/a";

                if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                else if (input.Length == 3)
                {
                    if (char.IsLetter(char.Parse(input[2][0].ToString())))
                    {
                        color = input[2];
                    }
                    else
                    {
                        weight = int.Parse(input[2]);
                    }
                }

                var engine = engines.Where(x => x.Model == engineModel).FirstOrDefault();
                Car currentCar = new Car(model, engine, weight, color);
                cars.Add(currentCar);
            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
