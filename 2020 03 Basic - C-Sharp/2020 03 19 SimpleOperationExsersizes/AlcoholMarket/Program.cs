using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //read beer, wine, brandy, whiskey, whiskeyPrice(lv/l), pcsall

            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double brandy = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());

            //calculation costs

            double brandyPrice = whiskeyPrice / 2;
            double winePrice = brandyPrice * 0.6;
            double beerPrice = brandyPrice * 0.2;

            double beerSum = beer * beerPrice;
            double wineSum = wine * winePrice;
            double brandySum = brandy * brandyPrice;
            double whiskeySum = whiskeyPrice * whiskey;

            double totalCosts = beerSum + wineSum + brandySum + whiskeySum;

            // write               
            Console.WriteLine($"{totalCosts:f2}");
        }
    }
}
