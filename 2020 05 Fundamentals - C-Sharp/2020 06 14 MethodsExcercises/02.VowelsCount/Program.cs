using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            CountVowels(word);
        }

        static void CountVowels(string word)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'A' ||
                    word[i] == 'o' || word[i] == 'O' ||
                    word[i] == 'e' || word[i] == 'E' ||
                    word[i] == 'i' || word[i] == 'I' ||
                    word[i] == 'u' || word[i] == 'U')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
