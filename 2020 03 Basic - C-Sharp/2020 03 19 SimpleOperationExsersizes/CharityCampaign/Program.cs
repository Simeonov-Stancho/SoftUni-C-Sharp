using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            //read days, confectioner

            int days = int.Parse(Console.ReadLine());
            int confectioner = int.Parse(Console.ReadLine());
            int cake = int.Parse(Console.ReadLine());
            int wafle = int.Parse(Console.ReadLine());
            int pancake = int.Parse(Console.ReadLine());

            // Calculation cake, waffle, pancake

            int cakeCount = cake * confectioner;
            int wafleCount = wafle * confectioner;
            int pancakeCount = pancake * confectioner;

            double cakeSum = cakeCount * 45.00;
            
            double wafleSum = wafleCount * 5.80;
           
            double pancakeSum = pancakeCount * 3.20;
            
            double totalSum = cakeSum + wafleSum + pancakeSum;
            double totalCost = totalSum / 8;

            double totalDonation = days * (totalSum - totalCost);

            //write
            
            Console.WriteLine($"{totalDonation:f2}");
        }
    }
}
