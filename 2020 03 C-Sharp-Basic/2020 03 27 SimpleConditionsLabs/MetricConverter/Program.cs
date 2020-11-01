using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            string insertUunit = Console.ReadLine();
            string outUnit = Console.ReadLine();



            if (insertUunit == "mm")
            {
                double centimeters = 0.1 * lenght;
                double meters = 0.001 * lenght;

                if (outUnit == "cm")
                {
                    Console.WriteLine($"{ centimeters:f3}");
                }

                else if (outUnit == "m")
                {
                    Console.WriteLine($"{meters:f3}");
                }

                else
                {
                    Console.WriteLine($"{lenght:f3}");
                }

            }

            else if (insertUunit == "cm")
            {
                double millimeters = 10 * lenght;
                double meters = 0.01 * lenght;

                if (outUnit == "mm")
                {
                    Console.WriteLine($"{ millimeters:f3}");
                }

                else if (outUnit == "m")
                {
                    Console.WriteLine($"{meters:f3}");
                }
                else
                {
                    Console.WriteLine($"{lenght:f3}");
                }
            }

            else
            {
                double millimeters = 1000 * lenght;
                double centimeters = 100 * lenght;

                if (outUnit == "mm")
                {
                    Console.WriteLine($"{ millimeters:f3}");
                }

                else if (outUnit == "cm")
                {
                    Console.WriteLine($"{centimeters:f3}");
                }
                else
                {
                    Console.WriteLine($"{lenght:f3}");
                }
            }
        }
    }
}