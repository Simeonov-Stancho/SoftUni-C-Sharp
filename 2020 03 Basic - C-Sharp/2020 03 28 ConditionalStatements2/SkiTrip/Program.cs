using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string rate = Console.ReadLine();

            double price = 0;
            int overNight = days - 1;   // overnight = days -1;
            
            
            // price: "room for one person" = 18.00; "apartment" =25.00; "president apartment" = 35.00;

            if (days < 10)
            {
                switch (typeRoom)
                {
                    case ("room for one person"):
                        price = 18.00;
                        break;

                    case ("apartment"):
                        price = 25.00 - 25 * 0.30;
                        break;

                    default:
                        price = 35.00 - 35*0.10;
                        break;
                       
                }
            }
            else if (days >=10 && days < 15)
            {
                switch (typeRoom)
                {
                    case ("room for one person"):
                        price = 18.00;
                        break;

                    case ("apartment"):
                        price = 25.00 - 25 * 0.35;
                        break;

                    default:
                        price = 35.00 - 35 * 0.15;
                        break;

                }
            }
            else
            {
                switch(typeRoom)
                {
                    case ("room for one person"):
                        price = 18.00;
                    break;

                    case ("apartment"):
                        price = 25.00 - 25 * 0.50;
                    break;

                    default:
                        price = 35.00 - 35 * 0.20;
                    break;

                }
            }

            double totalPrice = overNight * price;      //totalrice = overnight * price  - discount;
           
            //rate "positive" extraPrice = totalPrice *0.75; "negative" extraPrice = totalPrice *0.90;
            if (rate == "positive")
            {
               double extraPrice = totalPrice * 1.25;
                Console.WriteLine($"{ extraPrice:f2}");
            }
            else
            {
                double extraPrice = totalPrice * 0.90;
                Console.WriteLine($"{ extraPrice:f2}");
            }

        }
    }
}
