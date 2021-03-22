using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //01.Import Users
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(db, inputJson));

            //02. Import Products
            //string inputJson = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportUsers(db, inputJson));

            //03. Import Categories
            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(db, inputJson));

            //04. Import Categories and Products
            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(db, inputJson));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                                        .Where(x => x.Name != null)
                                        .ToList();

            context.Categories.AddRange(categories);

            //foreach (var category in categories)
            //{
            //    if (category.Name != null)
            //    {
            //        context.Categories.Add(category);
            //    }
            //}

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            return $"Successfully imported {context.SaveChanges()}";
        }
    }
}