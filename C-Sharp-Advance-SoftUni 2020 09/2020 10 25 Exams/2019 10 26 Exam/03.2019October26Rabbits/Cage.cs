using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;
        private string name;
        private int capacity;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Rabbit>();
        }

        public List<Rabbit> Data { get { return this.data; } set {this.data=value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > this.data.Count)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            bool isExist = data.Exists(r => r.Name == name);

            if (isExist)
            {
                data.RemoveAll(r => r.Name == name);
            }

            return isExist;
        }

        public void RemoveSpecies(string species)
        {
            bool isExist = data.Exists(r => r.Species == species);

            if (isExist)
            {
                data.RemoveAll(r => r.Species == species);
            }
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = data.Find(r => r.Name == name);
            rabbit.Available = false;
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbits = data.FindAll(r => r.Species == species).ToArray();

            foreach (var rabbbit in rabbits)
            {
                rabbbit.Available = false;
            }

            return rabbits;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in data)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
