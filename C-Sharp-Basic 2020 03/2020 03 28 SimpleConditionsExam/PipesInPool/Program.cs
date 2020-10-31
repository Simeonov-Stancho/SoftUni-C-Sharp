using System;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //read 
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());


            //Calculate
            double qtyP1 = P1 * H;
            double qtyP2 = P2 * H;
            double qty = qtyP1 + qtyP2;

            double y = qtyP1 / qty * 100;
            double z = qtyP2 / qty * 100;
            double x = ((qty) / V) * 100;

            //print if not full
            if (V >= qty)
            {
                Console.WriteLine($"The pool is {Math.Truncate(x)}% full. Pipe 1: {Math.Truncate(y)}%. Pipe 2: {Math.Truncate(z)}%.");
            }

            //print if it's full
            else
            {
                Console.WriteLine($"For {H} hours the pool overflows with { qty - V } liters.");
            }
            
            
        }
    }
}
