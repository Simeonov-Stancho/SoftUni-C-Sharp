using System;

namespace _01._2020August09
{
    class Program
    {
        static void Main(string[] args)
        {

            01.2020August09 First Quest

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                List<string> command = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "InsertSpace")
                {
                    
                }

                else if (command[0] == "Reverse")
                {
                    
                }

                else if (command[0] == "ChangeAll")
                {
                   
                }

                else if (command[0] == "ChangeAll")
                {

                }

                
            }



            2.2020August09 Second quest;

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




            03.2020August09 Third Quest;

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> carsInformation = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<string> cars = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string car = cars[0];
                int mileage = int.Parse(cars[1]);
                int fuel = int.Parse(cars[2]);

                carsInformation.Add(car, new List<int>());
                carsInformation[car].Add(mileage);
                carsInformation[car].Add(fuel);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                List<string> command = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "Drive")
                {
                    
                }

                else if (command[0] == "Refuel")
                {
                    
                }

                else if (command[0] == "Revert")
                {
                   
                }
            }

            carsInformation = carsInformation
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var cars in carsInformation)
            {
                string car = cars.Key;
                int mileage = cars.Value[0];
                int fuel = cars.Value[1];

                Console.WriteLine($"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }
}
