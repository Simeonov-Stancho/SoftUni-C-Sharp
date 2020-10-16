using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Data = new List<Car>();
        }

        public List<Car> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (this.Capacity > this.Data.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isExist = this.data.Exists(c => c.Manufacturer == manufacturer
                                         && c.Model == model);
            if (isExist)
            {
                data.RemoveAll(c => c.Manufacturer == manufacturer
                            && c.Model == model);
            }

            return isExist;
        }

        public Car GetLatestCar()
        {
            if (this.Data.Count == 0)
            {
                return null;
            }

            else
            {
                return this.data.Find(c => c.Year == this.data.Max(y => y.Year));
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            bool isExist = this.data.Exists(c => c.Manufacturer == manufacturer
                                         && c.Model == model);
            if (isExist)
            {
                return this.data.Find(c => c.Manufacturer == manufacturer
                                            && c.Model == model);
            }

            else
            {
                return null;
            }
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            if (this.data.Count > 0)
            {
                foreach (var car in data)
                {
                    sb.AppendLine(car.ToString());
                }
            }

            string statistics = sb.ToString().Trim();
            return statistics;
        }
    }
}