using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double result = 0;

            //operation = +; -; *; print (result) and (even or odd)
            //operation = / ; print (result)
            //operation ; %; print (ostatyk)
            // if / 0 - print special text

            if (operation == "+" )
            {
                result = n1 + n2;
            }

            else if ( operation == "-" )
            {
                result = n1 - n2;
            }

            else if ( operation == "*")
            {
                result = n1 * n2;
            }
            else if (operation == "/")
            {
                result = n1 / n2;
            }

            else if (operation == "%")
            {
                result = n1 % n2;
            }

            if (operation == "+" || operation == "-" || operation == "*")
            {
                if (result %2 ==0)
                {
                    Console.WriteLine($"{ n1} { operation } { n2} = { result} - even");
                }
                else
                {
                    Console.WriteLine($"{ n1} { operation } { n2} = { result} - odd");
                }
                              
            }
            else if (operation == "/")
            {
                if ( n2 == 0.00)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} / {n2} = {result:f2}");
                }
                
            }
            else if (operation == "%")
            {
                if (n2 == 0.00)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} % {n2} = {result}");
                }

            }

        }

    }
}
