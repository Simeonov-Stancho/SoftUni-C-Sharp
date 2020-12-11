using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
        {
            get
            {
                return this.components.ToList().AsReadOnly();
            }
        }

        public IReadOnlyCollection<IPeripheral> Peripherals
        {
            get
            {
                return this.peripherals.ToList().AsReadOnly();
            }
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                else
                {
                    return base.OverallPerformance + this.components.Average(c => c.OverallPerformance);
                }
            }

        }

        public override decimal Price
        {
            get
            {
                return base.Price
                             + this.components.Sum(c => c.Price)
                             + this.peripherals.Sum(p => p.Price);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(c => c.GetType().Name == peripherals.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || !this.components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent componentForRemove = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(componentForRemove);

            return componentForRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheralForRemove = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralForRemove);

            return peripheralForRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" {string.Format(SuccessMessages.ComputerComponentsToString, this.components.Count)}");

            foreach (IComponent component in components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            double averageOverallPerformance = 0;
            if (this.Peripherals.Count != 0)
            {
                averageOverallPerformance = this.Peripherals.Average(p => p.OverallPerformance);
            }

            sb.AppendLine($" {string.Format(SuccessMessages.ComputerPeripheralsToString, this.peripherals.Count, averageOverallPerformance.ToString("f2"))}");

            foreach (IPeripheral peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
