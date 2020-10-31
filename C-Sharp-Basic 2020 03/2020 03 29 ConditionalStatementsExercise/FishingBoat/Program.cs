using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherMan = int.Parse(Console.ReadLine());

            double price = 0;
            if (fisherMan <= 6)
            {
                switch (season)
                {
                    case "Spring":
                        price = 3000 * 0.9;
                        break;

                    case "Summer":
                    case "Autumn":
                        price = 4200 * 0.9;
                        break;

                    case "Winter":
                        price = 2600 * 0.9;
                        break;
                    
                }
            }

            else if (fisherMan <=11)
            {
                switch (season)
                {
                    case "Spring":
                        price = 3000 * 0.85;
                        break;

                    case "Summer":
                    case "Autumn":
                        price = 4200 * 0.85;
                        break;

                    case "Winter":
                        price = 2600 * 0.85;
                        break;

                }
            }

            else
            {
                switch (season)
                {
                    case "Spring":
                        price = 3000 * 0.75;
                        break;

                    case "Summer":
                    case "Autumn":
                        price = 4200 * 0.75;
                        break;

                    case "Winter":
                        price = 2600 * 0.75;
                        break;

                }
            }

            if ((budget >= price) )
            {
                if ((season != "Autumn") && (fisherMan % 2 == 0))
                {
                    Console.WriteLine($"Yes! You have {budget - price*0.95:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
                }
                
            }
            else
            {
                if ((price*0.95>=budget) && (season != "Autumn") && (fisherMan % 2 == 0))
                {
                    Console.WriteLine($"Not enough money! You need {price*0.95 - budget:f2} leva.");
                }
                else if (((price * 0.95 < budget) && (season != "Autumn") && (fisherMan % 2 == 0)))
                {
                    Console.WriteLine($"Yes! You have {budget - price * 0.95:f2} leva left.");
                }

                else
                {
                    Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
                }
               
            }
        }
    }
}
