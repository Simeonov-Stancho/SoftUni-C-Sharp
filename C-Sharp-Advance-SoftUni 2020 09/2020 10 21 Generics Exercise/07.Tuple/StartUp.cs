using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split()
                .ToArray();

            string personName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            string[] amountOfBeer = Console.ReadLine()
                .Split()
                .ToArray();

            string nameOfDrinker = amountOfBeer[0]; //:)
            int beerInLiters = int.Parse(amountOfBeer[1]);

            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            int integerFormat = int.Parse(input[0]);
            double doubleFormat = double.Parse(input[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(personName, address);
            Tuple<string, int> secondTuple = new Tuple<string, int>(nameOfDrinker, beerInLiters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(integerFormat, doubleFormat);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}