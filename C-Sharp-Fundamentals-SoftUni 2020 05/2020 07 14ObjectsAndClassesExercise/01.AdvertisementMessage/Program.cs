using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(AdvertismentMessage.GenereteMessage());
            }
        }
    }

    public class AdvertismentMessage
    {
        public static string[] Phrases = new string[]{"Excellent product.",
            "Such a great product.", "I always use that product.",
            "Best product of its category.", "Exceptional product.",
            "I can’t live without this product."};

        public static string[] Events = new string[] {"Now I feel good.",
            "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.", "I feel great!" };

        public static string[] Authors = new string[] { "Diana", "Petya", "Stella",
            "Elena", "Katya", "Iva", "Annie", "Eva" };

        public static string[] Cities = new string[] { "Burgas", "Sofia",
            "Plovdiv", "Varna", "Ruse" };

        public static string GenereteMessage()
        {
            Random rand = new Random();

            string currentPhrases = Phrases[rand.Next(0, 5)];
            string currentEvents = Phrases[rand.Next(0, 5)];
            string currentAuthors = Phrases[rand.Next(0, 7)];
            string currentCities = Phrases[rand.Next(0, 4)];

            return $"{currentPhrases} {currentEvents} {currentAuthors} – {currentCities}.";
        }
    }
}
