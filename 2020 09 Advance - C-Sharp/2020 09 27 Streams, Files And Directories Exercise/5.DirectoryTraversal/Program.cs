using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> directoryFiles = new Dictionary<string, Dictionary<string, double>>();
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows\Temp");  //folder thet you wont to check
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var currentFile in files)
            {
                string fileName = currentFile.Name;
                string fileExtension = currentFile.Extension;
                double fileSize = currentFile.Length / 1024.0;

                if (!directoryFiles.ContainsKey(fileExtension))
                {
                    directoryFiles[fileExtension] = new Dictionary<string, double>();
                }

                directoryFiles[fileExtension][fileName] = fileSize;
            }

            directoryFiles = directoryFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";
            
            foreach (var (extension, fileInfo) in directoryFiles)
            {
                File.AppendAllText(filePath, extension + Environment.NewLine);

                foreach (var (fileName, fileSize) in fileInfo.OrderBy(x => x.Value))
                {
                    File.AppendAllText(filePath, $"--{fileName} - {fileSize:F3}kb{Environment.NewLine}");
                }
            }
        }
    }
}
