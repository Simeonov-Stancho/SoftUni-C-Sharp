using System;
using System.Text.RegularExpressions;

namespace _02._2019December13BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string boss = Console.ReadLine();
                string pattern = @"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(boss))
                {
                    Match validBoss = regex.Match(boss);

                    Console.WriteLine($"{validBoss.Groups["boss"].Value}, The {validBoss.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {validBoss.Groups["boss"].Value.Length}");
                    Console.WriteLine($">> Armour: {validBoss.Groups["title"].Value.Length}");
                }

                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
