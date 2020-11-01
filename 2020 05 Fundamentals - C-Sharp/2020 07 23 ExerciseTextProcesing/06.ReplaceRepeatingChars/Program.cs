using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder(text);

            for (int i = 0; i < sb.Length-1; i++)
            {
                if (sb[i] == sb[i+1])
                {
                    char currentChar = sb[i];
                    sb.Remove(i, 2);
                    sb.Insert(i, currentChar);
                    i -= 1;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
