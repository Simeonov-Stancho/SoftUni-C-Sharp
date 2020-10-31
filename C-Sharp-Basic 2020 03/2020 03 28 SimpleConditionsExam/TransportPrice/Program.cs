using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            int n = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            //Calculate taxi startTax = 0.7; 
            double taxiDayTarif = 0.79;
            double taxiNightTarif = 0.90;
            

            double busDayTarif = 0.09;
            double busNightTarif = 0.09;
            

            double trainDayTarif = 0.06;
            double trainNightTarif = 0.06;
            
            
            if (dayOrNight == "day")
            {
                if (n < 100)
                {
                    if (n < 20)
                    {
                        double taxiTotalPrice = 0.7 + taxiDayTarif * n;
                        Console.WriteLine($"{taxiTotalPrice:f2}");
                    }
                    else
                    {
                        double busTotalPrice = busDayTarif * n;
                        Console.WriteLine($"{busTotalPrice:f2}");
                    }

                }

                else
                {
                    double trainTotalPrice = trainDayTarif * n;
                    Console.WriteLine($"{trainTotalPrice:f2}");
                }
            }
            else if (dayOrNight == "night")
            {
                if (n < 100)
                {
                    if (n < 20)
                    {
                        double taxiTotalPrice = 0.7 + taxiNightTarif * n;
                        Console.WriteLine($"{taxiTotalPrice:f2}");
                    }
                    else
                    {
                        double busTotalPrice = busNightTarif * n;
                        Console.WriteLine($"{busTotalPrice:f2}");
                    }

                }

                else
                {
                    double trainTotalPrice = trainNightTarif * n;
                    Console.WriteLine($"{trainTotalPrice:f2}");
                }
            }
            
        }
    }
}
