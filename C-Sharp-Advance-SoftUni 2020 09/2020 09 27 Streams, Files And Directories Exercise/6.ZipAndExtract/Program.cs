using System;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"../../../zipFile.zip";
            string extractPath = @"../../../unzipped";
            ZipFile.CreateFromDirectory(Environment.CurrentDirectory, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
