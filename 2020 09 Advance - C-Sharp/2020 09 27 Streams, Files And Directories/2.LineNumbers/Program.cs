using System;
using System.IO;
using System.Xml;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader text = new StreamReader("input2.txt"))
            {
                using (StreamWriter writerText = new StreamWriter("output2.txt"))
                {
                    string line = string.Empty;
                    int count = 1;

                    while ((line = text.ReadLine()) != null)
                    {
                        writerText.WriteLine($"{count}. {line}");
                        count++;
                    }
                }
            }

            //string path = Path.Combine("input.txt");
            //string dest = Path.Combine("output.txt");

            //var lines = File.ReadAllLines("input.txt");
            //int count = 1;

            //string[] output = new string[lines.Length];

            //foreach (var line in lines)
            //{
            //    output[count - 1] = $"{count}. {line}";
            //}

            //File.WriteAllLines(dest, output);
        }
    }
}
