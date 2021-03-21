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
            string inputJson = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(db, inputJson));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
        }
    }
}