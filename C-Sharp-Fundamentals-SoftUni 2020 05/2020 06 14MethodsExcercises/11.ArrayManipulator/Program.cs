using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArray[0] == "exchange")
                {
                    if (int.Parse(commandArray[1]) < 0 ||
                        int.Parse(commandArray[1]) > array.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    ExchangeArrayByIndex(commandArray, array);
                }

                else if (command == "max even")
                {
                    int index = ReturnMaxEven(array);
                    if (index != -1)
                    {
                        Console.WriteLine(index);
                    }

                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }

                else if (command == "max odd")
                {
                    int index = ReturnMaxOdd(array);
                    if (index != -1)
                    {
                        Console.WriteLine(index);
                    }

                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }

                else if (command == "min even")
                {
                    int index = ReturnMinEven(array);
                    if (index != -1)
                    {
                        Console.WriteLine(index);
                    }

                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }

                else if (command == "min odd")
                {
                    int index = ReturnMinOdd(array);
                    if (index != -1)
                    {
                        Console.WriteLine(index);
                    }

                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }

                else if (commandArray[0] == "first")
                {
                    int[] firstArray = new int[int.Parse(commandArray[1])];
                    int count = int.Parse(commandArray[1]);

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }

                    else if (commandArray[2] == "even")
                    {
                        firstArray = ReturnFirstEven(commandArray, array);
                        if (firstArray[0] == -1)
                        {
                            Console.WriteLine("[]");
                        }

                        else
                        {
                            Console.Write("[");
                            Console.Write(string.Join(", ", firstArray));
                            Console.WriteLine("]");
                        }
                    }

                    else if (commandArray[2] == "odd")
                    {
                        firstArray = ReturnFirstOdd(commandArray, array);

                        if (firstArray[0] == -1)
                        {
                            Console.WriteLine("[]");
                        }

                        else
                        {
                            Console.Write("[");
                            Console.Write(string.Join(", ", firstArray));
                            Console.WriteLine("]");
                        }
                    }
                }

                else if (commandArray[0] == "last")
                {
                    int[] lastArray = new int[int.Parse(commandArray[1])];
                    int count = int.Parse(commandArray[1]);

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }

                    else if (commandArray[2] == "even")
                    {
                        lastArray = ReturnLastEven(commandArray, array);
                        if (lastArray[0] == -1)
                        {
                            Console.WriteLine("[]");
                        }

                        else
                        {
                            Console.Write("[");
                            Console.Write(string.Join(", ", lastArray));
                            Console.WriteLine("]");
                        }
                    }

                    else if (commandArray[2] == "odd")
                    {
                        lastArray = ReturnLastOdd(commandArray, array);

                        if (lastArray[0] == -1)
                        {
                            Console.WriteLine("[]");
                        }

                        else
                        {
                            Console.Write("[");
                            Console.Write(string.Join(", ", lastArray));
                            Console.WriteLine("]");
                        }
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static void ExchangeArrayByIndex(string[] commandArray, int[] array)
        {
            int index = int.Parse(commandArray[1]);


            int[] firstArray = new int[array.Length - 1 - index];
            int[] secondArray = new int[index + 1];

            int counter = 0;
            for (int i = index + 1; i < array.Length; i++)
            {
                firstArray[counter] = array[i];
                counter++;
            }

            for (int i = 0; i < index + 1; i++)
            {
                secondArray[i] = array[i];
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                array[i] = firstArray[i];
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                array[firstArray.Length + i] = secondArray[i];
            }
        }

        static int ReturnMaxEven(int[] array)
        {
            int indexOfMaxEven = 0;
            bool isFind = false;
            int maxEven = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (maxEven <= array[i])
                    {
                        maxEven = array[i];
                        indexOfMaxEven = i;
                        isFind = true;
                    }
                }

                if (isFind == false)
                {
                    indexOfMaxEven = -1;
                }
            }
            return indexOfMaxEven;
        }

        static int ReturnMaxOdd(int[] array)
        {
            int indexOfMaxOdd = 0;
            bool isFind = false;
            int maxOdd = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (maxOdd <= array[i])
                    {
                        maxOdd = array[i];
                        indexOfMaxOdd = i;
                        isFind = true;
                    }
                }

                if (isFind == false)
                {
                    indexOfMaxOdd = -1;
                }
            }
            return indexOfMaxOdd;
        }

        static int ReturnMinEven(int[] array)
        {
            int indexOfMinEven = 0;
            bool isFind = false;
            int minEven = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (minEven >= array[i])
                    {
                        minEven = array[i];
                        indexOfMinEven = i;
                        isFind = true;
                    }
                }

                if (isFind == false)
                {
                    indexOfMinEven = -1;
                }
            }
            return indexOfMinEven;
        }

        static int ReturnMinOdd(int[] array)
        {
            int indexOfMinOdd = 0;
            bool isFind = false;
            int minOdd = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (minOdd >= array[i])
                    {
                        minOdd = array[i];
                        indexOfMinOdd = i;
                        isFind = true;
                    }
                }

                if (isFind == false)
                {
                    indexOfMinOdd = -1;
                }
            }
            return indexOfMinOdd;
        }

        static int[] ReturnFirstEven(string[] commandArray, int[] array)
        {
            int count = int.Parse(commandArray[1]);
            int[] firstEvenArray = new int[count];
            int currentCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    firstEvenArray[currentCount] += (array[i]);
                    currentCount++;

                    if (currentCount == count)
                    {
                        break;
                    }
                }
            }

            if (currentCount == 0)
            {
                firstEvenArray[0] = -1;
            }

            else if (currentCount < count)
            {
                int[] newArray = new int[currentCount];
                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] = firstEvenArray[i];
                }

                firstEvenArray = newArray;
            }

            return firstEvenArray;
        }

        static int[] ReturnFirstOdd(string[] commandArray, int[] array)
        {
            int count = int.Parse(commandArray[1]);
            int[] firstOddArray = new int[count];
            int currentCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    firstOddArray[currentCount] += (array[i]);
                    currentCount++;

                    if (currentCount == count)
                    {
                        break;
                    }
                }
            }

            if (currentCount == 0)
            {
                firstOddArray[0] = -1;
            }

            else if (currentCount < count)
            {
                int[] newArray = new int[currentCount];
                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] = firstOddArray[i];
                }

                firstOddArray = newArray;
            }

            return firstOddArray;
        }

        static int[] ReturnLastEven(string[] commandArray, int[] array)
        {
            int count = int.Parse(commandArray[1]);
            int[] lastEvenArray = new int[count];
            int currentCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    lastEvenArray[currentCount] += (array[i]);
                    currentCount++;

                    if (currentCount == count)
                    {
                        break;
                    }
                }
            }

            if (currentCount == 0)
            {
                lastEvenArray[0] = -1;
            }

            else if (currentCount <= count)
            {
                int[] newArray = new int[currentCount];
                int a = 0;
                for (int i = newArray.Length - 1; i >= 0; i--)
                {
                    newArray[a] = lastEvenArray[i];
                    a++;
                }

                lastEvenArray = newArray;
            }

            return lastEvenArray;
        }

        static int[] ReturnLastOdd(string[] commandArray, int[] array)
        {
            int count = int.Parse(commandArray[1]);
            int[] lastOddArray = new int[count];
            int currentCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    lastOddArray[currentCount] += (array[i]);
                    currentCount++;

                    if (currentCount == count)
                    {
                        break;
                    }
                }
            }

            if (currentCount == 0)
            {
                lastOddArray[0] = -1;
            }

            else if (currentCount <= count)
            {
                int[] newArray = new int[currentCount];
                int a = 0;
                for (int i = newArray.Length - 1; i >= 0; i--)
                {
                    newArray[a] = lastOddArray[i];
                    a++;
                }

                lastOddArray = newArray;
            }

            return lastOddArray;
        }
    }
}
