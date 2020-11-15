using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }
    }
}
