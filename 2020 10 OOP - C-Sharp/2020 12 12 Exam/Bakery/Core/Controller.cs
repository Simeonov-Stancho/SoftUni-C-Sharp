using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;



        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }

            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            if (drink != null)
            {
                drinks.Add(drink);
            }

            return string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);

        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }

            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            if (food != null)
            {
                this.bakedFoods.Add(food);
            }

            return string.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {

            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }

            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table != null)
            {
                tables.Add(table);
            }

            return string.Format(OutputMessages.TableAdded, table.TableNumber);

        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            decimal totalIncome = this.totalIncome;

            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            this.tables.FirstOrDefault(t => t.TableNumber == tableNumber).Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().Trim();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(f => f.Name == drinkName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            this.tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables
                .FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            else
            {
                this.tables
                .FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople).Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
