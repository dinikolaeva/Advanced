using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class SratUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
            foreach (var integer in integers)
            {
                Console.WriteLine(integer);
            }
        }
    }
}
