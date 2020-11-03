using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //On leap year play 15% more
            

            //Caclulate Math.Floor(playTime)

            string yearType = Console.ReadLine();
            double hollidays = int.Parse(Console.ReadLine());    //not in weekends
            double travelWeekends = int.Parse(Console.ReadLine());       // when trqvel to homeTown         

            double Weekends = 48; // year = 48 weekends

            double weekendsSofia = 48 - travelWeekends;
            double playWeekendsSofia = 3.00 / 4.00 * weekendsSofia;       //  and not at work 3/4 of weekends in Sofia
            double playSundayHome = travelWeekends;        //Travel h time and play on sunday

            double playHolliday = hollidays * 2 / 3;       // play 2/3 of hollidays

                     
            double playTime = playWeekendsSofia + playSundayHome + playHolliday;

            if (yearType == "leap")
            {
                playTime += playTime * 0.15;
                Console.WriteLine(Math.Floor(playTime));
            }

            else
            {
                Console.WriteLine(Math.Floor(playTime));
            }
        }
    }
}
