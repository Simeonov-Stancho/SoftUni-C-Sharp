using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private const string NOT_ENOUGHT_MONEY_MSG = "{0} can't afford {1}";
        private const string ENOUGHT_MONEY_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bagOfProducts;

        private Person()
        {
            this.bagOfProducts = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXC_MSG);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_PRICE_EXC_MSG);
                }

                this.money = value;
            }
        }

        private IReadOnlyCollection<Product> BagOfProducts
        {
            get { return (IReadOnlyCollection<Product>)this.bagOfProducts; }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.bagOfProducts.Add(product);
                return String.Format(ENOUGHT_MONEY_MSG, this.Name, product.Name);
            }

            else
            {
                return String.Format(NOT_ENOUGHT_MONEY_MSG, this.Name, product.Name);
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.bagOfProducts)}";
        }
    }
}
