using System;
using System.IO;

namespace _1.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("UpData", "input.txt");
            string dest = Path.Combine("UpData", "output.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (TextReader text = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create))
                    {
                        using (TextWriter writerText = new StreamWriter(destFile))
                        {
                            int count = 1;
                            string line = string.Empty;

                            while ((line = text.ReadLine()) != null)
                            {
                                if (count % 2 == 0)
                                {
                                    writerText.WriteLine(line);
                                }

                                count++;
                            }
                        }
                    }
                }
            }
        }
    }
}
