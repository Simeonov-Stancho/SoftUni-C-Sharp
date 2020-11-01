using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            //start point
            int startPoint = int.Parse(Console.ReadLine());


            //if startPoint>= bonus point =5

            double bonus = 0.00;

            if (startPoint <= 100)
            { 
                bonus = 5;
            }

            else if (startPoint > 1000)
            {
                bonus = 0.1 * startPoint;
            }
            
            else 
            {
                bonus = 0.2 * startPoint; 
            }

            if ( startPoint % 2 == 0 )
            {
                bonus = bonus + 1;

            }

            else if (startPoint % 10 == 5)
          
            {
                bonus = bonus + 2;
            }


            Console.WriteLine(bonus);
            Console.WriteLine(startPoint + bonus);
        }
    }
}
