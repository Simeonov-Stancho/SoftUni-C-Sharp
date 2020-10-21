using System;
using System.Linq;

namespace Threeuple
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
            string town = personInfo[3];
            if (personInfo.Length == 5)
            {
                town = town + " " + personInfo[4];
            }

            string[] amountOfBeer = Console.ReadLine()
                .Split()
                .ToArray();

            string nameOfDrinker = amountOfBeer[0]; //:)
            int beerInLiters = int.Parse(amountOfBeer[1]);
            bool isDrunk = false;
            if (amountOfBeer[2] == "drunk")
            {
                isDrunk = true;
            }

            string[] bankAccountInfo = Console.ReadLine()
                .Split()
                .ToArray();

            string name = bankAccountInfo[0];
            double accountBalance = double.Parse(bankAccountInfo[1]);
            string bankName = bankAccountInfo[2];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(personName, address, town);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(nameOfDrinker, beerInLiters, isDrunk);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
