using System;

using PizzaCalories.Core;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
