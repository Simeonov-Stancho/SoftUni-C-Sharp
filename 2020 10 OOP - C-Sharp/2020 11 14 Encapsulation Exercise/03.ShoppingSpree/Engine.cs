using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        private readonly ICollection<Person> persons;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                this.ParsePersonInput();
                this.ParseProductInput();

                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] command = input
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                    Person currentPerson = this.persons.FirstOrDefault(n => n.Name == command[0]);
                    Product currentProduct = this.products.FirstOrDefault(n => n.Name == command[1]);

                    if (currentPerson != null && currentProduct != null)
                    {
                        string result = currentPerson.BuyProduct(currentProduct);
                        Console.WriteLine(result);
                    }

                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }
                }

                foreach (Person currentPErson in this.persons)
                {
                    Console.WriteLine(currentPErson);
                }
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ParsePersonInput()
        {
            List<string> inputPerson = Console.ReadLine()
                                        .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            for (int i = 0; i < inputPerson.Count; i++)
            {
                List<string> currentPersonInfo = inputPerson[i]
                                        .Split("=", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

                string name = currentPersonInfo[0];
                decimal money = decimal.Parse(currentPersonInfo[1]);

                this.persons.Add(new Person(name, money));
            }
        }

        private void ParseProductInput()
        {
            List<string> inputProducts = Console.ReadLine()
                                        .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            for (int i = 0; i < inputProducts.Count; i++)
            {
                List<string> currentProductInfo = inputProducts[i]
                                        .Split("=", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

                string name = currentProductInfo[0];
                decimal cost = decimal.Parse(currentProductInfo[1]);

                products.Add(new Product(name, cost));
            }
        }
    }
}
