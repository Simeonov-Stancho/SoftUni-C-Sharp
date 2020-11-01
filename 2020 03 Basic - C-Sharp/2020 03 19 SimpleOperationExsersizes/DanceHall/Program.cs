using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            //read L, W, A in m.

            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());


            //Objects place calculation in meters

            double danceHall = L * W;
            double wardrobe = A * A;
            double bench = (L * W) / 10;



            //Dancer place in cantimeters

            double dancerPlace = 40 * 0.01 * 0.01;
            double dancerMove = 7000 * 0.01 * 0.01;
            double dancer = dancerPlace + dancerMove;

            // calculation free space

            double hallspace = danceHall - wardrobe - bench;


            //Calculation dancer Math.Floor

            double dancercount = hallspace / dancer;

            double dancerPcs = (Math.Floor(dancercount)) ;
            
                        
            Console.WriteLine($"{dancerPcs}");
        }
    }
}
