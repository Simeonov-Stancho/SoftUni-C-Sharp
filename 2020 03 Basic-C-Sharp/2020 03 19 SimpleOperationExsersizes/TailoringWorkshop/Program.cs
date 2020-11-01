using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {

            //input tablecloth tablecover  pcs tablecloth = tablecover


            int tablePcs = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double hignht = double.Parse(Console.ReadLine());

            //caluclation 

            double tablecoverLenght = (lenght) / 2;


            double tableCloth = (lenght+0.60) * (hignht+0.60);
            double tableCover = tablecoverLenght * tablecoverLenght;

            double tableClothPriceUSD = tablePcs * tableCloth * 7.00 ;
            double tableCoverPriceUSD = tablePcs * tableCover * 9.00 ;
            double totalPriceUSD = tableCoverPriceUSD + tableClothPriceUSD;

            double tableClothPriceBGN = tableClothPriceUSD * 1.85;
            double tableCoverPriceBGN =  tableCoverPriceUSD * 1.85;
            double totalPriceBGN = tableCoverPriceBGN + tableClothPriceBGN;
            

            // print
            Console.WriteLine($"{totalPriceUSD:f2} USD");
            Console.WriteLine($"{totalPriceBGN:f2} BGN");
        }
    }
}
