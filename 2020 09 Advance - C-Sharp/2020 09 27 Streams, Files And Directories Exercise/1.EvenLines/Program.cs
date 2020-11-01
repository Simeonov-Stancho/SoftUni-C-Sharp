using System;
using System.IO;
using System.Linq;

namespace _1.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = string.Empty;
                int count = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (count % 2 == 0)
                    {
                        line = line.Replace('-', '@');
                        line = line.Replace(',', '@');
                        line = line.Replace('.', '@');
                        line = line.Replace('!', '@');
                        line = line.Replace('?', '@');
                        string[] reversedString = line.Split().Reverse().ToArray();

                        Console.WriteLine(string.Join(" ", reversedString));
                    }

                    count++;
                }
            }
        }
    }
}
