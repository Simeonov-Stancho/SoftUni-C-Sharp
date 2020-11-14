using System;

namespace _03CruiseShip
{
    class Program
    {
        static void Main(string[] args)
        {
            string kindCruize = Console.ReadLine();
            string roomKind = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double price = 0;
            double discount = 0;

            if (kindCruize == "Mediterranean")
            {
                switch (roomKind)
                {
                    case "standard cabin":
                        price = 27.50;
                        break;

                    case "cabin with balcony":
                        price = 30.20;
                        break;

                    case "apartment":
                        price = 40.50;
                        break;
                }
            }

            else if (kindCruize == "Adriatic")
            {
                switch (roomKind)
                {
                    case "standard cabin":
                        price = 22.99;
                        break;

                    case "cabin with balcony":
                        price = 25.00;
                        break;

                    case "apartment":
                        price = 34.99;
                        break;
                }
            }

            else
            {
                switch (roomKind)
                {
                    case "standard cabin":
                        price = 23.00;
                        break;

                    case "cabin with balcony":
                        price = 26.60;
                        break;

                    case "apartment":
                        price = 39.80;
                        break;
                }
            }
            if (nights > 7)
            {
                discount = 0.25 * price * nights * 4;
            }

            double holiday = nights * 4 * price - discount;

            Console.WriteLine($"Annie's holiday in the {kindCruize} sea costs {holiday:f2} lv.");
        }
    }
}
