using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace _6.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("c:\\xampp");

            double size = 0;

            foreach (var file in files)
            {
                var info = new FileInfo(file);
                size += info.Length;
            }

            size = size / 1024 / 1024;
            File.WriteAllText("output.txt", size.ToString());
        }
    }
}
