using System;
using System.Text.RegularExpressions;

namespace _02._2019December07Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int successfulRegistrationsCount = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"U\$(?<userName>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[\d]+)P@\$";


                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    string userName = regex.Match(input).Groups["userName"].Value;
                    string password = regex.Match(input).Groups["password"].Value;

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {userName}, Password: {password}");
                    successfulRegistrationsCount++;
                }

                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
