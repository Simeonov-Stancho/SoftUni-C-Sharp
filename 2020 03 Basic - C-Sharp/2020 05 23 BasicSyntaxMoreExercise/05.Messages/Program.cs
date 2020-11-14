using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            string output = "";

            for (int i = 0; i < numbersCount; i++)
            {
                string number = Console.ReadLine();

                int numberDigit = number.Length - 1;
                int mainDigit = int.Parse(number) % 10;
                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                if (mainDigit == 0)
                {
                    output += " ";
                    continue;
                }

                int letterIndex = (offset + numberDigit);

                int asciiCode = 97 + letterIndex;
                char letter = (char)asciiCode;
                output += letter;
            }
            Console.WriteLine(output);
         }
    }
}
