using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int left = 5;
            int right = 5;

            EqualityScale<int> newScale= new EqualityScale<int>(left,right);

            Console.WriteLine(newScale.AreEqual());
        }
    }
}
