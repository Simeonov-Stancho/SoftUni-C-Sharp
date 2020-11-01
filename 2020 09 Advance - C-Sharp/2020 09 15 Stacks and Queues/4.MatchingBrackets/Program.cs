using System;
using System.Collections;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        { 
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (currentChar == '(')
                {
                    stack.Push(i);
                }

                else if (currentChar == ')')
                {
                    int firstPossition = stack.Pop();
                    int length = i - firstPossition + 1;
                    string currentExpression = expression.Substring(firstPossition, length);
                    Console.WriteLine(currentExpression);
                }
            }
        }
    }
}
