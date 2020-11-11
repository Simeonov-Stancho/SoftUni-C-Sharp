using System;

namespace _05Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double rest = double.Parse(Console.ReadLine());

            double restCoin = Math.Floor(rest * 100);
           
            int coin = 0;

            while (restCoin > 0.00)
            {
                if (restCoin >= 200)
                {
                    coin++;
                    restCoin -= 200;
                    continue;
                }
                else if (restCoin >= 100)
                {
                    coin++;
                    restCoin -= 100;
                    continue;
                }
                else if (restCoin >= 50)
                {
                    coin++;
                    restCoin -= 50;
                    continue;
                }
                else if (restCoin >= 20)
                {
                    coin++;
                    restCoin -= 20;
                    continue;
                }
                else if (restCoin >= 10)
                {
                    coin++;
                    restCoin -= 10;
                    continue;
                }
                else if (restCoin >= 5)
                {
                    coin++;
                    restCoin -= 5;
                    continue;
                }
                else if (restCoin >= 2)
                {
                    coin++;
                    restCoin -= 2;
                    continue;
                }
                else if (restCoin >= 1)
                {
                    coin++;
                    restCoin -= 1;
                    continue;
                }
            }
            if (coin > 0)
            {
                Console.WriteLine(coin);
            }

        }
    }
}
