using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            
            if (a > b)

                Console.Write(a);
            else
            {

                Console.Write(b);
            }
        }
    }
}
