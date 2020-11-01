using System;

namespace _2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //read input

            double meters = double.Parse(Console.ReadLine());

            //calculate

            double totalPrice = meters * 7.61;


            // substract discount
            double discount = totalPrice * 0.18;

            double finalPrice = totalPrice - discount;

            //print
            
            Console.WriteLine();
        }
    }
}
