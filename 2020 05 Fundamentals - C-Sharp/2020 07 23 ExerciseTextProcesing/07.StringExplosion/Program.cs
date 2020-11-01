using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            int power = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (currentChar == '>')
                {
                    sb.Append(currentChar);
                    power += text[i + 1] - 48;
                }

                else if (power == 0)
                {
                    sb.Append(currentChar);
                }

                else
                {
                    power--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
