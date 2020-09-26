using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> guests = new HashSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                guests.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                guests.Remove(input);
            }

            Console.WriteLine(guests.Count);

            foreach (var guest in guests)
            {
                if (char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

            foreach (var guest in guests)
            {
                if (char.IsLetter(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}