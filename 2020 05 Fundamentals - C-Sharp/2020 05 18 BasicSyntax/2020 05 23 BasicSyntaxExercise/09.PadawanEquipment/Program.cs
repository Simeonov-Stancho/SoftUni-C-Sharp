using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            //enough to buy all of the equipment, or how much more money he needs.

            int freeBelts = students / 6;
            double beltsDiscount = freeBelts * beltsPrice;
            double equipmenPrice = Math.Ceiling(1.1 * students) * lightsabersPrice + robesPrice * students + beltsPrice * students - beltsDiscount;


            if (money >= equipmenPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmenPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(equipmenPrice - money):f2}lv more.");
            }
        }
    }
}
