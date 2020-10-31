using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string kindTicket = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double price = 0;
            
            switch (kindTicket)
            {
                case "Premiere":
                price = 12.00;
                    break;

                case "Normal":
                    price = 7.50;
                    break;
                
                default:
                    price = 5.00;
                   break;
            }

            Console.WriteLine($"{(price * r * c):f2} leva, income");

        }
    }
}
