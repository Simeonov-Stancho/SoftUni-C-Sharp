using System;

namespace _06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 97; i < n + 97; i++)
            {
                for (int x = 97; x < n + 97; x++)
                {
                    for (int y = 97; y < n + 97; y++)
                    {
                        char firstChar = (char)i;
                        char secondChar = (char)x;
                        char thirdChar = (char)y;

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
