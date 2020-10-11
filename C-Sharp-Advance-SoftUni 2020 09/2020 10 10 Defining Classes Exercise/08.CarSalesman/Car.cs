using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;

namespace _08.CarSalesman
{
    class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Model + ":");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");

            if (Engine.Displacement == -1) sb.AppendLine($"    Displacement: n/a");
            else sb.AppendLine($"    Displacement: {Engine.Displacement}");

            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");

            if (Weight == -1) sb.AppendLine($"  Weight: n/a");
            else sb.AppendLine($"  Weight: {Weight}");

            sb.Append($"  Color: {Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
