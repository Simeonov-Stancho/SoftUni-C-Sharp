using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._2020August09DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();

            string pattern = @"(\=|\/)(?<places>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);
            MatchCollection validPlaces = regex.Matches(places);

            int travelPoints = 0;
            List<string> placesList = new List<string>();

            foreach (Match place in validPlaces)
            {
                travelPoints += place.Groups["places"].Length;
                placesList.Add(place.Groups["places"].Value);
            }

            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", placesList));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
