using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;
        
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.Data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count 
        {
            get { return this.data.Count; }
        }

        public List<Present> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public void Add(Present present)
        {
            if (this.Capacity > this.Data.Count)
            {
                data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            bool isExist = data.Exists(p => p.Name == name);

            if (isExist)
            {
                data.RemoveAll(p => p.Name == name);
            }

            return isExist;
        }

        public Present GetHeaviestPresent()
        {
            return data.Find(p => p.Weight == data.Max(p => p.Weight));
        }

        public Present GetPresent(string name)
        {
            return data.Find(p => p.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
