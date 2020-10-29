using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double salles = double.Parse(Console.ReadLine());

            double comission = 0;
            bool isValid = true;

            if (town == "Sofia")
            {
                if (0 <= salles && salles <= 500)
                {
                    comission = 0.05;
                }
                else if (500 < salles && salles <= 1000)
                {
                    comission = 0.07;
                }
                else if (1000 < salles && salles <= 10000)
                {
                    comission = 0.08;
                }
                else if (salles > 10000)
                {
                    comission = 0.12;
                }
                else
                {
                    isValid = false;
                }
            }
            else if (town == "Varna")
            {
                if (0 <= salles && salles <= 500)
                {
                    comission = 0.045;
                }
                else if (500 < salles && salles <= 1000)
                {
                    comission = 0.075;
                }
                else if (1000 < salles && salles <= 10000)
                {
                    comission = 0.10;
                }
                else if (salles > 10000)
                {
                    comission = 0.13;
                }
                else
                {
                    isValid = false;
                }
            }
            else if (town == "Plovdiv")
            {
                if (0 <= salles && salles <= 500)
                {
                    comission = 0.055;
                }
                else if (500 < salles && salles <= 1000)
                {
                    comission = 0.08;
                }
                else if (1000 < salles && salles <= 10000)
                {
                    comission = 0.12;
                }
                else if (salles > 10000)
                {
                    comission = 0.145;
                }
                else
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false ;
            }

            if (isValid )
            {
                Console.WriteLine($"{ salles * comission:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
            
        }
    }
}
