using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string command = string.Empty;
            Queue<string> carsOnQueue = new Queue<string>();

            int carPassed = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    string currentCar = command;
                    carsOnQueue.Enqueue(currentCar);
                }

                else if (command == "green")
                {
                    int remainigTime = greenDuration;

                    while (remainigTime > 0 && carsOnQueue.Count > 0)
                    {
                        string currentCar = carsOnQueue.Peek();
                        int carNameLength = currentCar.Length;

                        if (remainigTime - carNameLength > 0)
                        {
                            carsOnQueue.Dequeue();
                            remainigTime -= carNameLength;
                            carPassed++;
                        }

                        else if (remainigTime + freeWindowDuration >= carNameLength)
                        {
                            carsOnQueue.Dequeue();
                            carPassed++;
                            remainigTime -= carNameLength;
                        }

                        else
                        {
                            string hitPoint = currentCar.Substring(remainigTime + freeWindowDuration, 1);
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {hitPoint}.");
                            return;
                        }
                    }
                }
            }

            if (command == "END")
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPassed} total cars passed the crossroads.");
                return;
            }
        }
    }
}
