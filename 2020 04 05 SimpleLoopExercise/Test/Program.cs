using System;

namespace Hristogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double under200Counter = 0;
            double between200And399Counter = 0;
            double between400And599Counter = 0;
            double between600And799Counter = 0;
            double above800Counter = 0;
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;
            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 200)
                {
                    under200Counter += 1;
                }
                else if (200 <= number && number <= 399)
                {
                    between200And399Counter += 1;
                }
                else if (400 <= number && number <= 599)
                {
                    between400And599Counter = 1;
                }
                else if (600 <= number && number <= 799)
                {
                    between600And799Counter += 1;
                }
                else if (number >= 800)
                {
                    above800Counter += 1;
                }
            }
            p1 = (under200Counter / n) * 100;
            p2 = (between200And399Counter / n) * 100;
            p3 = (between400And599Counter / n) * 100;
            p4 = (between600And799Counter / n) * 100;
            p5 = (above800Counter / n) * 100;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}