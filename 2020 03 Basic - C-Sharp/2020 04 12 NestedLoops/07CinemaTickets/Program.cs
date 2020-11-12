using System;

namespace _07CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();

            double counterAll = 0;
            double studentTypeAll = 0;
            double standardTypeAll = 0;
            double kidTypeAll = 0;

            while (filmName != "Finish")
            {
                double counter = 0;
                double studentType = 0;
                double standardType = 0;
                double kidType = 0;

                int freePlace = int.Parse(Console.ReadLine());
                string ticketKind = Console.ReadLine();

                while (ticketKind != "End")
                {
                    switch (ticketKind)
                    {
                        case "student":
                            studentType++;
                            break;
                        case "standard":
                            standardType++;
                            break;
                        case "kid":
                            kidType++;
                            break;
                    }

                    counter = studentType + standardType + kidType;

                    if (freePlace == counter)
                    {
                        break;
                    }

                    ticketKind = Console.ReadLine();
                }

                Console.WriteLine($"{filmName} - {counter / freePlace * 100:f2}% full.");

                filmName = Console.ReadLine();

                counterAll += counter;
                studentTypeAll += studentType;
                standardTypeAll += standardType;
                kidTypeAll += kidType;

                if (filmName == "Finish")
                {
                    Console.WriteLine($"Total tickets: {counterAll}");
                    Console.WriteLine($"{studentTypeAll / counterAll * 100:f2}% student tickets.");
                    Console.WriteLine($"{standardTypeAll / counterAll * 100:f2}% standard tickets.");
                    Console.WriteLine($"{kidTypeAll / counterAll * 100:f2}% kids tickets.");
                    return;
                }
            }
        }
    }
}
