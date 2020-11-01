using System;
using System.IO;

namespace _4.MargeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstFileContent = File.ReadAllLines(@"..\..\..\FirstFile.txt");
            string[] secondFileContent = File.ReadAllLines(@"..\..\..\SecondFile.txt");

            for (int i = 0; i < firstFileContent.Length-1; i++)
            {
                File.AppendAllText(@"..\..\..\output.txt", $"{firstFileContent[i]}{Environment.NewLine}");
                File.AppendAllText(@"..\..\..\output.txt", $"{secondFileContent[i]}{Environment.NewLine}");
            }

            File.AppendAllText(@"..\..\..\output.txt", $"{firstFileContent[firstFileContent.Length-1]}{Environment.NewLine}");
            File.AppendAllText(@"..\..\..\output.txt", $"{secondFileContent[secondFileContent.Length-1]}");
        }
    }
}
