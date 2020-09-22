using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<char> text = new Queue<char>();
            Stack<string> previousText = new Stack<string>();
            string currentText = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (int.Parse(command[0]) == 1)
                {
                    currentText = ReturnQueueWithPrevius(text);
                    previousText = ReturnPrevius(previousText, currentText);

                    for (int k = 0; k < command[1].Length; k++)
                    {
                        text.Enqueue(command[1][k]);
                    }
                }

                else if (int.Parse(command[0]) == 2)
                {
                    currentText = ReturnQueueWithPrevius(text);
                    previousText = ReturnPrevius(previousText, currentText);

                    int count = int.Parse(command[1]);

                    for (int j = 0; j < text.Count; j++)
                    {
                        if (j < (text.Count - count))
                        {
                            text = ChangePossition(text);
                        }

                        else if (j >= (text.Count - count))
                        {
                            text.Dequeue();
                            j -= 1;
                        }
                    }
                }

                else if (int.Parse(command[0]) == 3)
                {
                    int count = int.Parse(command[1]);

                    for (int j = 0; j < text.Count; j++)
                    {
                        char currentChar = text.Peek();

                        if (j == count - 1)
                        {
                            Console.WriteLine(text.Dequeue());
                            text.Enqueue(currentChar);
                        }

                        else
                        {
                            text = ChangePossition(text);
                        }
                    }
                }

                else if (int.Parse(command[0]) == 4)
                {
                    text.Clear();
                    currentText = previousText.Pop();
                    for (int m = 0; m < currentText.Length; m++)
                    {
                        text.Enqueue(currentText[m]);
                    }

                    text.TrimExcess();
                }
            }
        }

        static string ReturnQueueWithPrevius(Queue<char> text)
        {
            string currentText = string.Empty;
            foreach (char currentChar in text)
            {
                currentText += currentChar;
            }

            return currentText;
        }

        static Stack<string> ReturnPrevius(Stack<string> previousText, string currentText)
        {
            previousText.Push(currentText);
            previousText.TrimExcess();
            return previousText;

        }

        static Queue<char> ChangePossition(Queue<char> text)
        {
            char currentChar = text.Peek();
            text.Dequeue();
            text.Enqueue(currentChar);
            text.TrimExcess();
            return text;
        }
    }
}
