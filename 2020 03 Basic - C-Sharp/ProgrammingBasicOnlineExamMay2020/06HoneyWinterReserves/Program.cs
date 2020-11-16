using System;

namespace _06HoneyWinterReserves
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededHoney = double.Parse(Console.ReadLine());
            string beeName = Console.ReadLine();

            double totalHoney = 0;

            while (beeName != "Winter has come")
            {
                double totalHoneyBee = 0;
                for (int months = 1; months <= 6; months++)
                {
                    double honey = double.Parse(Console.ReadLine());
                    totalHoneyBee += honey;
                }

                totalHoney += totalHoneyBee;

                if (totalHoneyBee < 0)
                {
                    Console.WriteLine($"{beeName} was banished for gluttony");
                }

                if (neededHoney <= totalHoney)
                {
                    Console.WriteLine($"Well done! Honey surplus {(totalHoney - neededHoney):f2}.");
                    return;
                }

                beeName = Console.ReadLine();
            }

            if (beeName == "Winter has come")
            {
                if (neededHoney <= totalHoney)
                {
                    Console.WriteLine($"Well done! Honey surplus {(totalHoney - neededHoney):f2}.");
                }

                else if (neededHoney > totalHoney)
                {
                    Console.WriteLine($"Hard Winter! Honey needed {(neededHoney - totalHoney):f2}.");
                }
            }
        }
    }
}
