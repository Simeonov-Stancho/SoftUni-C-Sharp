using System;

namespace OnTime_ForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //input examTime; arraivalTime

            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arraivalHours = int.Parse(Console.ReadLine());
            int arraivalMinutes = int.Parse(Console.ReadLine());


            arraivalMinutes += arraivalHours * 60; //time in minute
            examMinutes += examHours * 60;            //time in minute

            
            
            //before if arraivalTime <= time -30
            if (arraivalMinutes < examMinutes - 30)
            {
                Console.WriteLine("Early");

                if (arraivalMinutes > (examMinutes - 60) )
                {
                    Console.WriteLine($"{examMinutes - arraivalMinutes} minutes before the start");  //true
                }
                else
                {
                    Console.WriteLine($"{(examMinutes - arraivalMinutes)/60}:{((examMinutes - arraivalMinutes)%60):d2} hours before the start");
                }  
            }

            // late if arraivalTime > time
            else if (arraivalMinutes > examMinutes)
            {
                Console.WriteLine("Late");

                if (arraivalMinutes < (examMinutes + 60) )
                {
                    Console.WriteLine($"{(arraivalMinutes - examMinutes)} minutes after the start"); 
                }
                else
                {
                    Console.WriteLine($"{(arraivalMinutes - examMinutes)/60}:{((arraivalMinutes - examMinutes)%60):d2} hours after the start");
                }
            }

            //on time if arraivalTime >= time-30 || arraivalTime <= time
            else
            {
                Console.WriteLine("On time"); //true
                Console.WriteLine($"{examMinutes - arraivalMinutes} minutes before the start");
            }

        }
    }
}
