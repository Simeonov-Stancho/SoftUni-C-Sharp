using System;

namespace _05.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier data =new DateModifier(startDate, endDate);
            int difference = DateModifier.CalculatesDiff(data);
            Console.WriteLine(difference);
        }
    }
}
