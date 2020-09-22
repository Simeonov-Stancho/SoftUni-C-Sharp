using System;
using System.Text.RegularExpressions;

namespace _02._2020April04FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcod = Console.ReadLine();

                string pattern = @"@##*[A-Z][A-Za-z0-9]{4,}[A-Z]@#[#]*";
                Regex regex = new Regex(pattern);
                string productGroup = string.Empty;
                bool isValid = false;


                if (regex.IsMatch(barcod))
                {
                    isValid = true;
                    bool containNum = false;

                    string validBarcod = regex.Match(barcod).ToString();

                    for (int j = 0; j < validBarcod.Length; j++)
                    {
                        if (char.IsNumber(validBarcod[j]))
                        {
                            productGroup += (char)(validBarcod[j]);
                            containNum = true;
                        }
                    }

                    if (containNum == false)
                    {
                        productGroup = "00";
                    }
                }

                if (isValid)
                {
                    Console.WriteLine($"Product group: {productGroup}");
                }

                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

        }
    }
}
