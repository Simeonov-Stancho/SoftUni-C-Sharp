using System;
using System.IO;

namespace _5.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int partNumbers = 4;
            using (FileStream stream = new FileStream(@"../../../input.txt", FileMode.Open))
            {
                long fileLength = stream.Length / partNumbers;
                long lastFileLength = fileLength + stream.Length % 4;

                for (int i = 0; i < partNumbers; i++)
                {
                    using (FileStream currentSlice = new FileStream($"../../../Part-{i + 1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[1];
                        int count = 0;

                        while (count < fileLength)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            currentSlice.Write(buffer, 0, buffer.Length);
                            count++;
                        }
                    }
                }
            }
        }
    }
}
