using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());
            int charNum = character;

            if (charNum >= 65 && charNum <=90)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
