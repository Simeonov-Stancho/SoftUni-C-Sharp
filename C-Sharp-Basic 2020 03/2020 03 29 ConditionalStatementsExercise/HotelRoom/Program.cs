using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            //read month and overnight

            string month = Console.ReadLine();
            int overnight = int.Parse(Console.ReadLine());

            
            double priceStudio = 0;
            double priceApartment = 0;

            double discountStudio = 0;
            double discountApartment = 0;

            if (month == "May" || month == "October")
            {
                priceStudio = 50;
                priceApartment = 65;
            }

            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20;
                priceApartment = 68.70;
            }

            else
            {
                priceStudio = 76;
                priceApartment = 77;
            }

            if ((overnight > 7) && (overnight <=14) && (month == "May" || month == "October"))
            {
                discountStudio = 0.05;
                discountApartment = 0;
            }

            else if ((overnight > 14) && (month == "May" || month == "October"))
            {
                discountStudio = 0.3;
                discountApartment = 0.1;
            }

            else if ((overnight > 14) && (month == "June" || month == "September"))
            {
                discountStudio = 0.2;
                discountApartment = 0.1;
            }

            else if ((overnight > 14) )
            {
                discountApartment = 0.1;
            }
            else
            {
                discountStudio = 0;
                discountApartment = 0;
            }

            double totalPriceApartment = overnight * (priceApartment - priceApartment * discountApartment);
            double totalPriceStudio = overnight * (priceStudio - priceStudio * discountStudio);
            
                Console.WriteLine($"Apartment: {totalPriceApartment:f2} lv.");
                Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");

        }
    }
}
