using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(new char[]{',',' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            SortedDictionary<string, List<double>> participantsResult = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < participants.Count; i++)
            {
                string demonName = participants[i];
                int health = Health(demonName);

                double damage = 0;

                damage = CalculateDemageBeforeMyltiplyAndDevision(demonName);

                damage = CalculateDemageAfterMyltiplyAndDevision(demonName, damage);

                participantsResult.Add(demonName, new List<double>());
                participantsResult[demonName].Add(health);
                participantsResult[demonName].Add(damage);
            }

            foreach (var participant in participantsResult)
            {
                Console.WriteLine($"{participant.Key} - {participant.Value[0]} health, {participant.Value[1]:f2} damage");
            }


            static int Health(string demonName)
            {
                string pattern = @"[^0-9+*.\/-]";
                Regex regex = new Regex(pattern);
                MatchCollection healthCharacter = regex.Matches(demonName);

                int health = 0;
                string iDontKnowHowToConvertMatchToChar = string.Empty;

                for (int i = 0; i < healthCharacter.Count; i++)
                {
                    iDontKnowHowToConvertMatchToChar += healthCharacter[i].ToString();
                }

                for (int j = 0; j < iDontKnowHowToConvertMatchToChar.Length; j++)
                {
                    health += iDontKnowHowToConvertMatchToChar[j];
                }

                return health;

            }

            static double CalculateDemageBeforeMyltiplyAndDevision(string demonName)
            {
                string pattern = @"(\-|\+)*(\d+\.)*\d+";
                Regex regex = new Regex(pattern);
                MatchCollection demonsDamagesNum = regex.Matches(demonName);

                double damage = 0;
                for (int q = 0; q < demonsDamagesNum.Count; q++)
                {
                    damage += double.Parse(demonsDamagesNum[q].ToString());
                }

                return damage;
            }

            static double CalculateDemageAfterMyltiplyAndDevision(string demonName, double damage)
            {
                string patternMultiply = @"\*";
                Regex regexM = new Regex(patternMultiply);
                MatchCollection myltiply = regexM.Matches(demonName);

                for (int j = 0; j < myltiply.Count; j++)
                {
                    damage *= 2;
                }

                string patternD = @"\/";
                Regex regexD = new Regex(patternD);
                MatchCollection division = regexD.Matches(demonName);

                for (int j = 0; j < division.Count; j++)
                {
                    damage /= 2;
                }

                return damage;
            }
        }
    }
}
