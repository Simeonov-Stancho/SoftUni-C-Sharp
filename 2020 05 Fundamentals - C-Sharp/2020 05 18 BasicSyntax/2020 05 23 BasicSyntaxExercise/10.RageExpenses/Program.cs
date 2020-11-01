using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetCount = lost / 2;
            int mouseCount = lost / 3;
            int keyboardCount = 0;

            for (int i = 1; i <= lost; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardCount++;
                }
            }

            int displayCount = keyboardCount / 2;
            double totalCosts = headsetPrice * headsetCount + mousePrice * mouseCount + keyboardPrice * keyboardCount + displayPrice * displayCount;
            Console.WriteLine($"Rage expenses: {totalCosts:f2} lv.");
        }
    }
}
