using System;
using System.Text.RegularExpressions;

namespace _02._2019August03Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"(\*|\@)(?<tag>[A-Z][a-z]{3,})\1: (?<firstGroup>\[[A-Za-z]\])\|(?<secondGroup>\[[A-Za-z]\])\|(?<thirdGroup>\[[A-Za-z]\])\|$";
                Regex regex = new Regex(pattern);

                Match validMessage = regex.Match(input);

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("Valid message not found!");
                }

                else
                {
                    string tag = validMessage.Groups["tag"].Value;
                    string firstGroup = validMessage.Groups["firstGroup"].Value;
                    string secondGroup = validMessage.Groups["secondGroup"].Value;
                    string thirdGroup = validMessage.Groups["thirdGroup"].Value;

                    int firstGroupSum = SumASCII(firstGroup);
                    int secondGroupSum = SumASCII(secondGroup);
                    int thirdGroupSum = SumASCII(thirdGroup);

                    Console.WriteLine($"{tag}: {firstGroupSum} {secondGroupSum} {thirdGroupSum}");      //if they are more
                }
            }
        }

        static int SumASCII(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    sum += input[i];
                }
            }

            return sum;
        }
    }
}
