using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            // read odd years +=toys
            //even age +=money
            //money = 10;
            //money = -1 take from brother
            //calculate toys * price*Toys

            int age = int.Parse(Console.ReadLine());
            double loubryMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            double money = 10;
            double toysCount = 0;
            double savedMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += money;
                    savedMoney -= 1;
                    money += 10;
                }

                else
                {
                    toysCount++;
                }
            }

            double toysMoney = toyPrice * toysCount;
            double totalSaving = savedMoney + toysMoney;

            if (totalSaving >= loubryMachinePrice)
            {
                Console.WriteLine($"Yes! {(totalSaving - loubryMachinePrice):f2}");
            }

            else
            {
                Console.WriteLine($"No! {(loubryMachinePrice - totalSaving):f2}");
            }
        }
    }
}
