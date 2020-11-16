using System;

namespace _03HoneyHarvest
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            double flowersCount = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double honey = 0;

            if (season == "Spring")
            {
                switch (flower)
                {
                    case "Sunflower":
                        honey = 10;
                        break;

                    case "Daisy":
                        honey = 12 * 1.1;
                        break;

                    case "Lavender":
                        honey = 12;
                        break;


                    case "Mint":
                        honey = 10 * 1.1;
                        break;
                }
            }

            else if (season == "Summer")
            {
                switch (flower)
                {
                    case "Sunflower":
                        honey = 8 * 1.1;
                        break;

                    case "Daisy":
                        honey = 8 * 1.1;
                        break;

                    case "Lavender":
                        honey = 8 * 1.1;
                        break;


                    case "Mint":
                        honey = 12 * 1.1;
                        break;
                }
            }

            else if (season == "Autumn")
            {
                switch (flower)
                {
                    case "Sunflower":
                        honey = 12 * 0.95;
                        break;

                    case "Daisy":
                        honey = 6 * 0.95;
                        break;

                    case "Lavender":
                        honey = 6 * 0.95;
                        break;


                    case "Mint":
                        honey = 6 * 0.95;
                        break;
                }
            }

            Console.WriteLine($"Total honey harvested: {(honey * flowersCount):f2}");
        }
    }
}
