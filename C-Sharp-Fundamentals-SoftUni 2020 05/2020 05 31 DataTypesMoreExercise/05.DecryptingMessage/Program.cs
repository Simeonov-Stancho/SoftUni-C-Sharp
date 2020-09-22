using System;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string message = "";

            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int decryptedSymbol = symbol + key;
                message += (char)decryptedSymbol;
            }
            Console.WriteLine(message);
        }
    }
}
