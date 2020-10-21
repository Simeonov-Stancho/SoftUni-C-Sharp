using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string actualString = Console.ReadLine();
                Console.WriteLine(new Box<string>(actualString).ToString());
            }
        }
    }
}