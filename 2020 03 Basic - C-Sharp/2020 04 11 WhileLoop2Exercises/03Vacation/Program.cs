using System;

namespace _03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripMoney = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            int allDays = 0;
            int spendedDays = 0;

            while (tripMoney > money && spendedDays < 5)
            {
                string input = Console.ReadLine();
                double moneyOperation = double.Parse(Console.ReadLine());

                if (input == "spend")
                {
                    spendedDays++;
                    allDays++;

                    if (money >= moneyOperation)
                    {
                        money -= moneyOperation;
                        continue;
                    }
                    else
                    {
                        money = 0;
                        continue;
                    }
                }
                else
                {
                    spendedDays = 0;
                    allDays++;
                    money += moneyOperation;
                    continue;
                }
            }

            if (spendedDays == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{allDays}");
            }
            else if (money >= tripMoney)
            {
                Console.WriteLine($"You saved the money for {allDays} days.");
            }
        }
    }
}
