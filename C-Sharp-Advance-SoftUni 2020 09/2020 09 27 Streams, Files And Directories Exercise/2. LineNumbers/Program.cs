using System;
using System.IO;
using System.Linq;

namespace _2._LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] outputLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int countLetters = 0;
                int countMarks = 0;

                for (int j = 0; j < line.Length; j++)
                {
                    if (char.IsLetter(line[j]))
                    {
                        countLetters++;
                    }

                    else if (char.IsPunctuation(line[j]))
                    {
                        countMarks++;
                    }
                }

                string outputLine = $"Line {i + 1}: {line} ({countLetters})({countMarks})";
                outputLines[i] = outputLine;
            }

            File.WriteAllLines("../../../output.txt", outputLines);
        }
    }
}