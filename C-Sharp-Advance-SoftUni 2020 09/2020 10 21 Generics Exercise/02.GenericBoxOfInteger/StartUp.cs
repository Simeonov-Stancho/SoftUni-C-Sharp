using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int actualString = int.Parse(Console.ReadLine());
                Console.WriteLine(new Box<int>(actualString).ToString());
            }
        }
    }
}
