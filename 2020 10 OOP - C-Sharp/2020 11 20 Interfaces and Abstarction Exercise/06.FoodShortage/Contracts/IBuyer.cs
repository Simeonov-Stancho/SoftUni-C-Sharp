﻿namespace _06.FoodShortage.Contracts
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Food { get; }

        void BuyFood();
    }
}