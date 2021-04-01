using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifference(startDate,endDate));
        }
    }
}
