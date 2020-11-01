using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int input1 = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(input1, input2));
            }

            else if (type == "string")
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                Console.WriteLine(GetMax(input1, input2));
            }

            else if (type == "char")
            {
                char input1 = char.Parse(Console.ReadLine());
                char input2 = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(input1, input2));
            }
        }

        static int GetMax(int num1, int num2)
        {
            int maxNumber = num1.CompareTo(num2);

            if (maxNumber > 0)
            {
                return num1;
            }

            else
            {
                return num2;
            }
        }

        static string GetMax(string num1, string num2)
        {
            int maxNumber = num1.CompareTo(num2);

            if (maxNumber > 0)
            {
                return num1;
            }

            else
            {
                return num2;
            }
        }

        static char GetMax(char num1, char num2)
        {
            int maxNumber = num1.CompareTo(num2);

            if (maxNumber > 0)
            {
                return num1;
            }

            else
            {
                return num2;
            }
        }
    }
}
