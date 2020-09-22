using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringRepeatFast(Console.ReadLine(), int.Parse(Console.ReadLine())));
        }

        static string StringRepeatSlowMethod(string input, int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                result += input;
            }

            return result;
        }

        static string StringRepeatFast(string input, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(input);
            }

            return result.ToString();
        }
    }
}