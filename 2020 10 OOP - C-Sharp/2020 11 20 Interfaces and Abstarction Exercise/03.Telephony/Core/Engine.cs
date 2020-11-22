using System;
using System.Linq;

using _03.Telephony.Contracts;
using _03.Telephony.Exceptions;
using _03.Telephony.Models;

namespace _03.Telephony.Core
{
    public class Engine
    {
        private StationaryPhone stationaryPhone;
        private SmartPhone smartPhone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new SmartPhone();
        }

        public void Run()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] sites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            DialNumbers(numbers);
            BrowseSites(sites);
        }

        private void DialNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(this.stationaryPhone.Call(number));
                    }

                    else
                    {
                        Console.WriteLine(this.smartPhone.Call(number));
                    }
                }

                catch (InvalidNumberException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(this.smartPhone.Brawse(site));
                }

                catch (InvalidURLException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}