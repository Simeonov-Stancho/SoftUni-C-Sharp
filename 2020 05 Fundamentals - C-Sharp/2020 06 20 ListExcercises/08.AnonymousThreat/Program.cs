using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "3:1")
            {
                List<string> commandList = command
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .ToList();

                List<string> newList = new List<string>();
                if (commandList[0] == "merge")
                {
                    int startIndex = int.Parse(commandList[1]);
                    int endIndex = int.Parse(commandList[2]);
                    string word = string.Empty;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex > (input.Count - 1))
                    {
                        endIndex = (input.Count - 1);
                    }

                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }

                    if (startIndex > (input.Count - 1))
                    {
                        startIndex = (input.Count - 1);
                    }

                    for (int i = 0; i < startIndex; i++)
                    {
                        newList.Add(input[i]);
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        word += input[i];
                    }

                    newList.Add(word);

                    for (int i = endIndex + 1; i < input.Count; i++)
                    {
                        newList.Add(input[i]);
                    }

                    input = newList;
                }

                else if (commandList[0] == "divide")
                {
                    int index = int.Parse(commandList[1]);
                    int partitions = int.Parse(commandList[2]);

                    string word = input[index];

                    int charLenght = word.Length / partitions;

                    List<string> dividedWord = new List<string>();
                    int startIndex = 0;

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            dividedWord.Add(word.Substring(startIndex, word.Length - startIndex));
                        }

                        else
                        {
                            dividedWord.Add(word.Substring(startIndex, charLenght));
                            startIndex += charLenght;
                        }
                    }

                    input.RemoveAt(index);
                    input.InsertRange(index, dividedWord);

                }
            }

            Console.WriteLine(string.Join(' ', input));
        }
    }
}