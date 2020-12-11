using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckThisComputerExistInComputersCollection(computerId);
            IComputer currentComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent currentComponent = null;

            if (componentType == "CentralProcessingUnit")
            {
                currentComponent = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "Motherboard")
            {
                currentComponent = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "PowerSupply")
            {
                currentComponent = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "RandomAccessMemory")
            {
                currentComponent = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "SolidStateDrive")
            {
                currentComponent = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "VideoCard")
            {
                currentComponent = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            currentComputer.AddComponent(currentComponent);
            this.components.Add(currentComponent);

            return string.Format(SuccessMessages.AddedComponent, currentComponent.GetType().Name, currentComponent.Id, currentComputer.Id);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }


            IComputer currentComputer = null;

            if (computerType == "DesktopComputer")
            {
                currentComputer = new DesktopComputer(id, manufacturer, model, price);
            }

            else if (computerType == "Laptop")
            {
                currentComputer = new Laptop(id, manufacturer, model, price);
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }


            this.computers.Add(currentComputer);

            return string.Format(SuccessMessages.AddedComputer, currentComputer.Id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckThisComputerExistInComputersCollection(computerId);

            IComputer currentComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral currentPeripherals = null;

            if (peripheralType == "Headset")
            {
                currentPeripherals = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Keyboard")
            {
                currentPeripherals = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Monitor")
            {
                currentPeripherals = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Mouse")
            {
                currentPeripherals = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            currentComputer.AddPeripheral(currentPeripherals);
            this.peripherals.Add(currentPeripherals);

            return string.Format(SuccessMessages.AddedPeripheral, currentPeripherals.GetType().Name, currentPeripherals.Id, currentComputer.Id);
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0 || this.computers.Any(c => c.Price <= budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer currentComputer = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .Where(c => c.Price <= budget).
                FirstOrDefault();

            return RemoveComputer(currentComputer);
        }

        public string BuyComputer(int id)
        {
            CheckThisComputerExistInComputersCollection(id);
            IComputer currentComputer = this.computers.FirstOrDefault(c => c.Id == id);
            
            return RemoveComputer(currentComputer);
        }

        public string GetComputerData(int id)
        {
            CheckThisComputerExistInComputersCollection(id);
            return this.computers.FirstOrDefault(c => c.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckThisComputerExistInComputersCollection(computerId);

            IComputer currentComputer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IComponent currentComponent = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            currentComputer.RemoveComponent(componentType);
            this.components.Remove(currentComponent);

            return string.Format(SuccessMessages.RemovedComponent, currentComponent.GetType().Name, currentComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckThisComputerExistInComputersCollection(computerId);

            IComputer currentComputer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IPeripheral currentPeriheral = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            currentComputer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(currentPeriheral);

            return string.Format(SuccessMessages.RemovedPeripheral, currentPeriheral.GetType().Name, currentPeriheral.Id);
        }

        private void CheckThisComputerExistInComputersCollection(int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private string RemoveComputer(IComputer currentComputer)
        {
            this.computers.Remove(currentComputer);
            return currentComputer.ToString();
        }
    }
}
